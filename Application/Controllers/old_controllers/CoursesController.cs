﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Repositories.IRepositories;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace Application.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IRepositoryAsync<Course> _repository;

        public CoursesController(IRepositoryAsync<Course> repository)
        {
            _repository = repository;
        }

        // GET: Teachers    
        [Authorize]
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

            var course = await _repository.GetAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
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
        public async Task<IActionResult> Create([Bind("CourseID,Date")] Course course)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var course = await _repository.GetAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,Date,TeacherID,SubjectID,ClassroomID")] Course course)
        {
            if (id != course.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(course.CourseID))
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
            return View(course);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var course = await _repository.GetAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _repository.GetAsync(id);
            await _repository.DeleteAsync(course);
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            var listCourses = _repository.GetAllAsync();
            return listCourses.Result.Any(t => t.CourseID == id);
        }
    }
}
