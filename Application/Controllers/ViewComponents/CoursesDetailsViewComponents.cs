using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Application.Controllers.ViewComponents
{
    public class CoursesDetailsViewComponents : ViewComponent
    {
        private readonly IRepositoryAsync<Course> _repository;

        public CoursesDetailsViewComponents(IRepositoryAsync<Course> repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var course = await GetCourseById(id);
            return View(course);
        }

        private async Task<List<Course>> GetCourseById(int id)
        {
            var course = await _repository.GetAllAsync();
            return course.Where(c => c.ID == id).ToList();
        }
    }
}
