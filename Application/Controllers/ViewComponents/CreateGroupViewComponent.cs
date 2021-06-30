using Application.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.ViewComponents
{
    public class CreateGroupViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Group group)
        {
            return View(group);
        }
    }
}
