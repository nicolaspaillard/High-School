using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.ViewComponents
{
    public class EditCourseViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Course course)
        {
            return View(course);
        }   
    }
}
