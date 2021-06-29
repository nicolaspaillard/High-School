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
                ProfileViewModel.Groups = await _groups.GetAllAsync();

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
            course = await _courses.GetAsync(course.CourseID);
            return ViewComponent("ListGrades", course);
        }
        public async Task<IActionResult> EditMissingModal(Course course)
        {
            return ViewComponent("EditMissing", course);
        }
        public async Task<IActionResult> EditGroupModal(int groupID)
        {
            var group = await _groups.GetAsync(groupID);
            return ViewComponent("EditGroup", group);
        }

        
        public async Task<IActionResult> EditGroup(int groupID)
        {
            var group = await _groups.GetAsync(groupID);
            return ViewComponent("EditGroup", group);
        }
        [HttpPost]        public async Task<IActionResult> EditGroup(Group group, List<int> StudentID)
        {
            ModelState.Remove("HomeRoomTeacher");
            ModelState.Remove("Students");
            group.HomeRoomTeacher = await _teachers.GetAsync((int)group.HomeRoomTeacherID);

            var students = new List<Student>();
            StudentID.ForEach(id => students.Add(_students.GetAsync(id).Result));
            group.Students = new();
            group.Students = students;
            if (ModelState.IsValid) await _groups.UpdateAsync(group);
            return ViewComponent("EditGroup", group);
        }
        [HttpPost]
        public async Task<IActionResult> EditMissing(Course course, List<int> StudentID)
        {
            return ViewComponent("EditMissing", course);
        }

        [HttpPost]
        public async Task<IActionResult> EditCourse(Course course, List<int> GroupID)
        {
            ModelState.Remove("Subject");
            ModelState.Remove("Teacher");
            ModelState.Remove("Classroom");
            course.Subject = await _subjects.GetAsync((int)course.SubjectID);
            course.Teacher = await _teachers.GetAsync((int)course.TeacherID);
            course.Classroom = await _classrooms.GetAsync((int)course.ClassroomID);

            var groups = new List<Group>();
            GroupID.ForEach(id => groups.Add(_groups.GetAsync(id).Result));
            course.Groups = new();
            course.Groups = groups;
            if (ModelState.IsValid) await _courses.UpdateAsync(course);
            return ViewComponent("EditCourse", course);
        }
        public async Task<IActionResult> CreateCourseModal(Course course)
        {
            return ViewComponent("CreateCourse", course);
        }
        public async Task<IActionResult> CreateCourse(Course course, List<int> GroupID)
        {
            course.Subject = (await _subjects.GetAsync((int)course.SubjectID));
            course.Teacher = (await _teachers.GetAsync((int)course.TeacherID));
            course.Classroom = (await _classrooms.GetAsync((int)course.ClassroomID));
            course.Groups = new();
            GroupID.ForEach(g => course.Groups.Add(_groups.GetAsync(g).Result));
            await _courses.CreateAsync(course);
            return ViewComponent("CreateCourse", course);

        }

        public async Task<IActionResult> CreateGroupModal(Group group)
        {
            return ViewComponent("CreateGroup", group);
        }
        public async Task<IActionResult> CreateGroup(Group group, List<int> StudentID)
        {
            group.HomeRoomTeacher = (await _teachers.GetAsync((int)group.HomeRoomTeacherID));
            group.Students= new();
            StudentID.ForEach(g => group.Students.Add(_students.GetAsync(g).Result));
            await _groups.CreateAsync(group);
            return ViewComponent("CreateGroup", group);

        }

        [HttpPost]
        public async Task<IActionResult> ListGrades(List<Grade> grades)
        {
            Course course = await _courses.GetAsync(grades.Select(g => (int)g.CourseID).FirstOrDefault());
            course.Grades = grades;
            if (ModelState.IsValid) await _courses.UpdateAsync(course);
            return ViewComponent("ListGrades", course);
        }

    }


}


