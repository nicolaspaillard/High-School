using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.ViewComponents
{
    public class PersonDetailsViewComponent : ViewComponent
    {
            public PersonDetailsViewComponent()
            {
            }

            public async Task<IViewComponentResult> InvokeAsync(Person person)
            {
                return View(person);
            }
        }
    }

