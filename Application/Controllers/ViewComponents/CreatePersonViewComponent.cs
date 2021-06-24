using Application.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.ViewComponents
{
    public class CreatePersonViewComponent : ViewComponent
    {
        IRepositoryAsync<Student> _students;
        IRepositoryAsync<Teacher> _teachers;
        IRepositoryAsync<Admin> _admins;

        public CreatePersonViewComponent(IRepositoryAsync<Student> students, IRepositoryAsync<Teacher> teachers, IRepositoryAsync<Admin> admins)
        {
            _students = students;
            _teachers = teachers;
            _admins = admins;
        }

        public async Task<IViewComponentResult> InvokeAsync(Person person)
        {
            return View(person);
        }
    }
}
