using System;
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

namespace Application.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsRepository _repository;

        public StudentsController(StudentsRepository repository)
        {
            _repository = repository;
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

            /*if (id == null)
            {
                return NotFound();
            }*/


            Guid currentGuid = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimConstants.ObjectId).Value);

            var student = await _repository.GetAsync(currentGuid);
            if (student == null)
            {
                return NotFound();
            }

        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Email,BirthDate")] Student student)
        {
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

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,BirthDate")] Student student)
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
