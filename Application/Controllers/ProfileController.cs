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
                ProfileViewModel.Person = person;
                List<Group> allGroups = await _groups.GetAllAsync();
                ProfileViewModel.Groups = allGroups?.Where(g => g.Students.Contains((Student)person))?.ToList();
                ProfileViewModel.HomeRoomTeacher = ProfileViewModel.Groups?.Count > 0 ? ProfileViewModel.Groups?.Select(g => g.HomeRoomTeacher).First() : null;
                List<Course> courses = ProfileViewModel.Groups?.SelectMany(g => g.Courses).ToList();
                ProfileViewModel.Courses = courses.Count > 0 ? courses : null;
                ProfileViewModel.Teachers = ProfileViewModel.Courses?.Select(c => c.Teacher).ToList();
                ProfileViewModel.Subjects = ProfileViewModel.Courses?.Select(c => c.Subject).ToList();
                ProfileViewModel.Grades = (await _grades.GetAllAsync())?.Where(g => g.StudentID == person.PersonID).ToList();
                ProfileViewModel.Missings = (await _missings.GetAllAsync())?.Where(m => m.StudentID == person.PersonID).ToList();
                return View(ProfileViewModel);
            }
            else if (person is Teacher)
            {
                ProfileViewModel.Person = person;
                ProfileViewModel.Courses = (await _courses.GetAllAsync())?.Where(c => c.Teacher.PersonID == person.PersonID)?.ToList();
                ProfileViewModel.Groups = ProfileViewModel.Courses?.SelectMany(c => c.Groups.Where(g => g.HomeRoomTeacher == person)).ToList();
                return View(ProfileViewModel);
            }
            else if (person is Admin)
            {
                ProfileViewModel.Person = person;
                ProfileViewModel.Courses = await _courses.GetAllAsync();
                return View(ProfileViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> EditCourseModal(Course course)
        {
            return ViewComponent("EditCourse", course);
        }
        public async Task<IActionResult> ListGradesModal(Course course)
        {
            return ViewComponent("ListGrades", course);
        }
        [HttpPost]
        public async Task<IActionResult> EditCourse(Course course, List<int> GroupID)
        {
            ModelState.Remove("Subject");
            ModelState.Remove("Teacher");
            ModelState.Remove("Classroom");
            course.Subject = (await _subjects.GetAllAsync()).FirstOrDefault(s => s.SubjectID == course.SubjectID);
            course.Teacher = (await _teachers.GetAllAsync()).FirstOrDefault(t => t.PersonID == course.TeacherID);
            course.Classroom = (await _classrooms.GetAllAsync()).FirstOrDefault(c => c.ClassroomID == course.ClassroomID);
            course.Groups = new();
            GroupID.ForEach(g => course.Groups.Add(_groups.GetAsync(g).Result));
            if (ModelState.IsValid) await _courses.UpdateAsync(course);
            return ViewComponent("EditCourse", course);
        }

        public async Task<IActionResult> CreateCourse(Course course, List<int> GroupID)
        {
            if (ModelState.IsValid) await _courses.CreateAsync(course);
            return ViewComponent("EditCourse", course);

        }
    }

}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 