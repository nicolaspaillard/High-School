﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dal;
using Models;
using Application.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Application.Repositories;
using Application.Controllers.Tools;

namespace Application.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IRepositoryAsync<Student> _repository;
        private AzureTools azureTools;

        public StudentsController(IRepositoryAsync<Student> students, IRepositoryAsync<Teacher> teachers, IRepositoryAsync<Admin> admins)
        {
            _repository = students;
            azureTools = new(students, teachers, admins);
        }

        // GET: Students
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        // GET: Students/Details/5
        [Authorize]
        public async Task<IActionResult> Details()
        {
            Guid currentGuid = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimConstants.ObjectId).Value);
            var student = await _repository.GetAsync(currentGuid);
            if (student == null)
            {
                return RedirectToAction(nameof(Create));
            }
            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,BirthDate")] Student student)
        {
            Guid currentGuid = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimConstants.ObjectId).Value);
            student.Email = User.Identity.Name;
            student.AzureID = currentGuid;

            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _repository.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,BirthDate,GroupID")] Student student)
        {
            if (id != student.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var student = await _repository.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _repository.GetAsync(id);
            await _repository.DeleteAsync(student);
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            var listStudents = _repository.GetAllAsync();
            return listStudents.Result.Any(s => s.PersonID == id);
        }
    }
}
// mdp  ad Sellers Chava = Vajo6106
