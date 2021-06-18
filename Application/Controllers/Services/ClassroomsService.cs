using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Models;

namespace Application.Controllers.Services
{
    public class ClassroomsService
    {
        private readonly IRepositoryAsync<Classroom> _repository;
        public ClassroomsService(IRepositoryAsync<Classroom> repository)
        {
            _repository = repository;
        }

        public List<Classroom> GetAll() => _repository.GetAllAsync().Result;
    }
}
