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
        private readonly IRepositoryAsync<Group> _groups;
        private readonly IRepositoryAsync<Student> _students;
        private readonly IRepositoryAsync<Course> _courses;

        public GroupsController(IRepositoryAsync<Group> groups, IRepositoryAsync<Student> students, IRepositoryAsync<Course> courses)
        {
            _groups = groups;
            _students = students;
            _courses = courses;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await _groups.GetAllAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            /*if (id == null)
            {
                return NotFound();
            }*/

            var group = await _groups.GetAsync(id);
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
        public async Task<IActionResult> Create([Bind("GroupID, HomeRoomTeacherID, Students, Courses")] Group group)
        {
            if (ModelState.IsValid)
            {
                await _groups.CreateAsync(group);
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

            var group = await _groups.GetAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupID, HomeRoomTeacherID, SubjectID, Students")] Group group)
        {
            if (id != group.GroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _groups.UpdateAsync(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(group.GroupID))
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
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupID, HomeRoomTeacherID, SubjectID")] Group group, List<int> StudentsID, List<int> CoursesID)
        {
            if (id != group.GroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    group.Students = new List<Student>();
                    group.Courses = new List<Course>();
                    var students = await _students.GetAllAsync();
                    var courses = await _courses.GetAllAsync();
                    StudentsID.ForEach(id => group.Students.Add(students.FirstOrDefault(s => s.PersonID == id)));
                    CoursesID.ForEach(id => group.Courses.Add(courses.FirstOrDefault(c => c.CourseID == id)));
                    await _groups.UpdateAsync(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(group.GroupID))
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

            var group = await _groups.GetAsync(id);
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
            var group = await _groups.GetAsync(id);
            await _groups.DeleteAsync(group);
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            var listGroups = _groups.GetAllAsync();
            return listGroups.Result.Any(t => t.GroupID == id);
        }
    }
}
