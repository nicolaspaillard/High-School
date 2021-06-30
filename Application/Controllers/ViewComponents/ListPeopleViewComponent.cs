using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.ViewComponents
{
    public class ListPeopleViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<Person> people)
        {
            return View(people != null? people : new List<Person>());
        }
    }
}
