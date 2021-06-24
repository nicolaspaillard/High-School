using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Models;

namespace Application.Controllers.Services
{
    public class StudentsService
    {
        private readonly IRepositoryAsync<Student> _repository;
        public StudentsService(IRepositoryAsync<Student> repository)
        {
            _repository = repository;
        }

        public List<Student> GetAll() => _repository.GetAllAsync().Result;
        public Student GetStudent(int id) => _repository.GetAsync(id).Result;
    }
}
