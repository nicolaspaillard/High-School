using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Models;

namespace Application.Repositories
{
    public class SubjectsRepository : IRepositoryAsync<Subject>
    {
        public Task<int> CreateAsync(Subject obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Subject obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subject>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Subject> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Subject obj)
        {
            throw new NotImplementedException();
        }
    }
}
