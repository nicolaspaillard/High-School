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
        #region InitRepo
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
        #endregion
        #region ProfileController
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
        #endregion
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var person = await _azureTools.RegisterAzureUser(User);
            ProfileViewModel.Person = person;
            if (person.Role == Role.Student)
            {
                Group group = ((Student)person).Group;
                if (group != null)
                {
                    ProfileViewModel.Groups.Add(group);
                    ProfileViewModel.HomeRoomTeacher = group.HomeRoomTeacher;
                    List<Course> courses = ProfileViewModel.Groups.SelectMany(g => g.Courses)?.ToList();
                    if (courses != null)
                    {
                        ProfileViewModel.Courses = courses;
                        ProfileViewModel.Subjects = courses.Select(c => c.Subject).ToList();
                        ProfileViewModel.Grades = (await _grades.GetAllAsync())?.Where(g => g.StudentID == person.PersonID).ToList();
                        ProfileViewModel.Missings = (await _missings.GetAllAsync())?.Where(m => m.StudentID == person.PersonID).ToList();
                    }
                }
                return View(ProfileViewModel);
            }
            else if (person.Role == Role.Teacher)
            {
                List<Course> courses = ((Teacher)person).Courses;
                if (courses != null)
                {
                    ProfileViewModel.Courses = courses;
                    ProfileViewModel.Groups = courses.SelectMany(c => c.Groups?.Where(g => g.HomeRoomTeacher.PersonID == person.PersonID)).ToList();
                }
                return View(ProfileViewModel);
            }
            else if (person.Role == Role.Admin)
            {
                ProfileViewModel.Courses = await _courses.GetAllAsync();
                ProfileViewModel.Groups = await _groups.GetAllAsync();
                ProfileViewModel.Students = (await _students.GetAllAsync())?.Select(s => (Person)s).ToList();
                ProfileViewModel.Teachers = (await _teachers.GetAllAsync())?.Select(t => (Person)t).ToList();
                ProfileViewModel.Classrooms = await _classrooms.GetAllAsync();
                return View(ProfileViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        #region Course
        public async Task<IActionResult> EditCourseModal(Course course)
        {
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
        #endregion
        #region Group
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
        [HttpPost]
        public async Task<IActionResult> EditGroup(Group group, List<int> StudentID)
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

        public async Task<IActionResult> CreateGroupModal(Group group)
        {
            return ViewComponent("CreateGroup", group);
        }
        public async Task<IActionResult> CreateGroup(Group group, List<int> StudentID)
        {
            group.HomeRoomTeacher = (await _teachers.GetAsync((int)group.HomeRoomTeacherID));
            group.Students = new();
            StudentID.ForEach(g => group.Students.Add(_students.GetAsync(g).Result));
            await _groups.CreateAsync(group);
            return ViewComponent("CreateGroup", group);

        }
        #endregion
        #region Grades
        public async Task<IActionResult> ListGradesModal(Course course)
        {
            course = await _courses.GetAsync(course.CourseID);
            return ViewComponent("ListGrades", course);
        }
        [HttpPost]
        public async Task<IActionResult> ListGrades(List<Grade> grades)
        {
            Course course = await _courses.GetAsync(grades.Select(g => (int)g.CourseID).FirstOrDefault());
            course.Grades = grades;
            if (ModelState.IsValid) await _courses.UpdateAsync(course);
            return ViewComponent("ListGrades", course);
        }
        #endregion
        #region Missing
        public async Task<IActionResult> EditMissingModal(Course course)
        {
            return ViewComponent("EditMissing", course);
        }


        [HttpPost]
        public async Task<IActionResult> EditMissing(Course course, List<int> StudentID)
        {
            ModelState.Remove("Subject");
            ModelState.Remove("Teacher");
            ModelState.Remove("Classroom");
            course = await _courses.GetAsync(course.CourseID);

            foreach (var missing in course.Missings.ToList())
            {
                await _missings.DeleteAsync(missing);
            }

            foreach (var id in StudentID)
            {
                if (!course.Missings.Select(m => m.StudentID).Contains((int)id))
                    await _missings.CreateAsync(new Missing { CourseID = course.CourseID, StudentID = id });
            }
            //MissingID.ForEach(id => missings.Add(_missings.GetAsync(id).Result));
            return ViewComponent("EditMissing", course);
        }
        #endregion
        #region Classroom
        public async Task<IActionResult> EditClassroomModal(Classroom classroom)
        {
            return ViewComponent("EditClassroom", classroom);
        }
        public async Task<IActionResult> EditClassroom(Classroom classroom)
        {
            if (ModelState.IsValid) await _classrooms.UpdateAsync(classroom);
            return ViewComponent("EditClassroom", classroom);
        }

        public async Task<IActionResult> ListClassrooms(List<Classroom> classrooms)
        {
            return ViewComponent("ListClassrooms", classrooms);
        }
        public async Task<IActionResult> CreateClassroomModal(Classroom classroom)
        {
            return ViewComponent("CreateClassroom", classroom);
        }
        public async Task<IActionResult> CreateClassroom(Classroom classroom)
        {
            if (ModelState.IsValid) await _classrooms.CreateAsync(classroom);
            return ViewComponent("CreateClassroom", classroom);
        }
        #endregion
    }
}


