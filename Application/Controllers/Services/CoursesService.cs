using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Models;

namespace Application.Controllers.Services
{
    public class CoursesService
    {
        private readonly IRepositoryAsync<Course> _repository;
        public CoursesService(IRepositoryAsync<Course> repository)
        {
            _repository = repository;
        }

        public List<Course> GetAll() => _repository.GetAllAsync().Result;
        public Course GetCourse(int id) => _repository.GetAsync(id).Result;
    }
}
