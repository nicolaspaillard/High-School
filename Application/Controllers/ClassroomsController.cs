using System;
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
    public class ClassroomsController : Controller
    {
        private readonly IRepositoryAsync<Classroom> _repository;

        public ClassroomsController(IRepositoryAsync<Classroom> repository)
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

            var classroom = await _repository.GetAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
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
        public async Task<IActionResult> Create([Bind("ID,Name")] Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(classroom);
                return RedirectToAction(nameof(Index));
            }
            return View(classroom);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var classroom = await _repository.GetAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return View(classroom);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Classroom classroom)
        {
            if (id != classroom.ClassroomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(classroom);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(classroom.ClassroomID))
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
            return View(classroom);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var classroom = await _repository.GetAsync(id);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classroom = await _repository.GetAsync(id);
            await _repository.DeleteAsync(classroom);
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            var listClassrooms = _repository.GetAllAsync();
            return listClassrooms.Result.Any(t => t.ClassroomID == id);
        }
    }
}
