using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Models;

namespace Application.Controllers.Services
{
    public class TeachersService
    {
        private readonly IRepositoryAsync<Teacher> _repository;
        public TeachersService(IRepositoryAsync<Teacher> repository)
        {
            _repository = repository;
        }

        public List<Teacher> GetAll() => _repository.GetAllAsync().Result; 
    }
}
