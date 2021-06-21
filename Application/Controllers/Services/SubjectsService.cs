using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Models;

namespace Application.Controllers.Services
{
    public class SubjectsService
    {
        private readonly IRepositoryAsync<Subject> _repository;
        public SubjectsService(IRepositoryAsync<Subject> repository)
        {
            _repository = repository;
        }

        public List<Subject> GetAll() => _repository.GetAllAsync().Result;
    }
}
