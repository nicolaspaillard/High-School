using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;
using Models;

namespace Application.Controllers
{
    public class MissingsController : Controller
    {
        private readonly MissingsRepository _repository;

        public MissingsController(MissingsRepository repository)
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

            var missing = await _repository.GetAsync(id);
            if (missing == null)
            {
                return NotFound();
            }

            return View(missing);
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
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Email,BirthDate")] Missing missing)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(missing);
                return RedirectToAction(nameof(Index));
            }
            return View(missing);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var missing = await _repository.GetAsync(id);
            if (missing == null)
            {
                return NotFound();
            }
            return View(missing);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,BirthDate")] Missing missing)
        {
            if (id != missing.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(missing);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(missing.ID))
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
            return View(missing);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var missing = await _repository.GetAsync(id);
            if (missing == null)
            {
                return NotFound();
            }

            return View(missing);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var missing = await _repository.GetAsync(id);
            await _repository.DeleteAsync(missing);
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            var listMissings = _repository.GetAllAsync();
            return listMissings.Result.Any(t => t.ID == id);
        }
    }
}
