﻿using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.ViewComponents
{
    public class EditClassroomViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Classroom classroom)
        {
            return View(classroom);
        }
    }
}
