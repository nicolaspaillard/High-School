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
        private readonly IRepositoryAsync<Student> _students;
        private readonly IRepositoryAsync<Teacher> _teachers;
        private readonly IRepositoryAsync<Admin> _admins;
        private readonly IRepositoryAsync<Group> _groups;
        private readonly IRepositoryAsync<Grade> _grades;
        private readonly IRepositoryAsync<Course> _courses;
        private readonly IRepositoryAsync<Missing> _missings;
        private readonly IRepositoryAsync<Classroom> _classrooms;
        private readonly IRepositoryAsync<Subject> _subjects;
        AzureTools _azureTools;
        ProfileViewModel ProfileViewModel = new();
        public ProfileController(IRepositoryAsync<Student> students,
                                IRepositoryAsync<Teacher> teachers,
                                IRepositoryAsync<Admin> admins,
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
            _admins = admins;
            _azureTools = new(students, teachers, admins);
        }
        // GET: Profile
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var person = await _azureTools.RegisterAzureUser(User);
            if (person is Student)
            {
                ProfileViewModel.Role = Role.Student;
                ProfileViewModel.Person = person;
                List<Group> allGroups = await _groups.GetAllAsync();
                ProfileViewModel.Groups = allGroups?.Where(g => g.Students.Contains((Student)person))?.ToList();
                ProfileViewModel.HomeRoomTeacher = ProfileViewModel.Groups.Count > 0 ? ProfileViewModel.Groups.Select(g => g.HomeRoomTeacher).First() : null;
                List<Course> courses = ProfileViewModel.Groups.SelectMany(g => g.Courses).ToList();
                ProfileViewModel.Courses = courses.Count > 0 ? courses : null;
                ProfileViewModel.Teachers = ProfileViewModel.Courses?.Select(c => c.Teacher).ToList();
                ProfileViewModel.Subjects = ProfileViewModel.Courses?.Select(c => c.Subject).ToList();
                ProfileViewModel.Grades = (await _grades.GetAllAsync())?.Where(g => g.StudentID == person.PersonID).ToList();
                ProfileViewModel.Missings = (await _missings.GetAllAsync())?.Where(m => m.StudentID == person.PersonID).ToList();
                return View(ProfileViewModel);
            }
            else if (person is Teacher)
            {
                ProfileViewModel.Role = Role.Teacher;
                ProfileViewModel.Person = person;
                ProfileViewModel.Courses = (await _courses.GetAllAsync())?.Where(c => c.Teacher.PersonID == person.PersonID)?.ToList();
                ProfileViewModel.Groups = ProfileViewModel.Courses?.SelectMany(c => c.Groups.Where(g => g.HomeRoomTeacher == person)).ToList();
                return View(ProfileViewModel);
            }
            else if (person is Admin)
            {
                ProfileViewModel.Role = Role.Admin;
                ProfileViewModel.Person = person;
                return View(ProfileViewModel);
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
