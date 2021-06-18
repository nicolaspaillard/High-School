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
    public class GroupsController : Controller
    {
        private readonly IRepositoryAsync<Group> _repository;

        public GroupsController(IRepositoryAsync<Group> repository)
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

            var group = await _repository.GetAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
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
        public async Task<IActionResult> Create([Bind("ID")] Group group)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(group);
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var group = await _repository.GetAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] Group group)
        {
            if (id != group.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(group.ID))
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
            return View(group);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var group = await _repository.GetAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var group = await _repository.GetAsync(id);
            await _repository.DeleteAsync(group);
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            var listGroups = _repository.GetAllAsync();
            return listGroups.Result.Any(t => t.ID == id);
        }
    }
}
