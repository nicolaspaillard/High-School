using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.ViewComponents
{
    public class ListClassroomsViewComponent : ViewComponent
    {        public async Task<IViewComponentResult> InvokeAsync(List<Classroom> classrooms)
        {
            return View(classrooms != null ? classrooms : new List<Classroom>());
        }
    }
}
