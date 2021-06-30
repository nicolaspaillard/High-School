using Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.ViewComponents
{
    public class ListGroupsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<Group> groups)
        {
            return View(groups != null ? groups: new List<Group>());
        }
    }
}
