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
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Application.Controllers.Tools;
using Application.Repositories;

namespace Application.Controllers
{
    public class ProfileController : Controller
    {
        private readonly StudentsRepository _students;
        private readonly TeachersRepository _teachers;
        private readonly IRepositoryAsync<Group> _groups;
        private readonly IRepositoryAsync<Grade> _grades;
        private readonly IRepositoryAsync<Course> _courses;
        private readonly IRepositoryAsync<Missing> _missings;
        private readonly IRepositoryAsync<Classroom> _classrooms;
        private readonly IRepositoryAsync<Subject> _subjects;
        AzureTools azureTools;
        ProfileViewModel ProfileViewModel = new();
        public ProfileController(StudentsRepository students,
                                TeachersRepository teachers,
                                IRepositoryAsync<Group> groups,
                                IRepositoryAsync<Grade> grades,
                                IRepositoryAsync<Course> courses,
                                IRepositoryAsync<Missing> missings,
                                IRepositoryAsync<Classroom> classrooms,
                                IRepositoryAsync<Subject> subjects)
        {
            _students = students;
            _teachers = teachers;
            _groups = groups;
            _grades = grades;
            _courses = courses;
            _missings = missings;
            _classrooms = classrooms;
            _subjects = subjects;
            azureTools = new(_students, _teachers);
        }
        // GET: Profile
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var person = azureTools.RegisterAzureUser(User);
            if (await person is Student)
            {
                ProfileViewModel.Person = await person;
                ProfileViewModel.Groups = (await _groups.GetAllAsync()).Where(g => g.Students.Contains(person.Result as Student)).ToList();
                ProfileViewModel.Courses = (await _courses.GetAllAsync()).Where(course => ProfileViewModel.Courses.Contains(course)).ToList();
                ProfileViewModel.Grades = (await _grades.GetAllAsync()).Where(g => g.StudentID == ((Student)person.Result).PersonID).ToList();
                return View(ProfileViewModel);
            }
            else if (await person is Teacher)
            {
                //traitement
                return View(await person);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
//        // GET: Profile/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students
//                .FirstOrDefaultAsync(m => m.PersonID == id);
//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // GET: Profile/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Profile/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("PersonID,FirstName,LastName,Email,BirthDate")] Student student)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(student);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }

//        // GET: Profile/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students.FindAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return View(student);
//        }

//        // POST: Profile/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("PersonID,FirstName,LastName,Email,BirthDate")] Student student)
//        {
//            if (id != student.PersonID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(student);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!StudentExists(student.PersonID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }

//        // GET: Profile/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students
//                .FirstOrDefaultAsync(m => m.PersonID == id);
//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // POST: Profile/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var student = await _context.Students.FindAsync(id);
//            _context.Students.Remove(student);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool StudentExists(int id)
//        {
//            return _context.Students.Any(e => e.PersonID == id);
//        }
//    }
//}
