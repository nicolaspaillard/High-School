using Dal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories.IRepositories
{
    public interface StudentRepositoryExtension
    {
        public Task<List<Teacher>> GetTeachersAsync(int id);
    }
}
