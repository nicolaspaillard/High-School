using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.ViewComponents
{
    public class ListGradesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Course course)
        {
            List<Grade> grades = new();
            foreach (var item in course.Groups.SelectMany(g => g.Students))
            {
                grades.Add(new Grade() {Student = item, StudentID = item.PersonID, Course=course, CourseID=course.CourseID});
            }
            return View(grades);
        }
    }
}
