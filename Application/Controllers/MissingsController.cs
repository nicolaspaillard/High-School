using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dal;
using Models;

namespace Application.Controllers
{
    public class MissingsController : Controller
    {
        private readonly HighSchoolContext _context;

        public MissingsController(HighSchoolContext context)
        {
            _context = context;
        }

        // GET: Missings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Missings.ToListAsync());
        }

        // GET: Missings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missing = await _context.Missings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (missing == null)
            {
                return NotFound();
            }

            return View(missing);
        }

        // GET: Missings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Missings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] Missing missing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(missing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(missing);
        }

        // GET: Missings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missing = await _context.Missings.FindAsync(id);
            if (missing == null)
            {
                return NotFound();
            }
            return View(missing);
        }

        // POST: Missings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] Missing missing)
        {
            if (id != missing.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(missing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MissingExists(missing.ID))
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

        // GET: Missings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var missing = await _context.Missings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (missing == null)
            {
                return NotFound();
            }

            return View(missing);
        }

        // POST: Missings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var missing = await _context.Missings.FindAsync(id);
            _context.Missings.Remove(missing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MissingExists(int id)
        {
            return _context.Missings.Any(e => e.ID == id);
        }
    }
}
