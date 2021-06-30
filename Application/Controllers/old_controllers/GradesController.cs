﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Repositories.IRepositories;
using Models;

namespace Application.Controllers
{
    public class GradesController : Controller
    {
        private readonly IRepositoryAsync<Grade> _repository;

        public GradesController(IRepositoryAsync<Grade> repository)
        {
            _repository = repository;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var grade = await _repository.GetAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Assessment,Value")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(grade);
                return RedirectToAction(nameof(Index));
            }
            return View(grade);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var grade = await _repository.GetAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            return View(grade);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Assessment,Value")] Grade grade)
        {
            if (id != grade.GradeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(grade);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(grade.GradeID))
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
            return View(grade);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var grade = await _repository.GetAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grade = await _repository.GetAsync(id);
            await _repository.DeleteAsync(grade);
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            var listGrades = _repository.GetAllAsync();
            return listGrades.Result.Any(g => g.GradeID == id);
        }
    }
}
