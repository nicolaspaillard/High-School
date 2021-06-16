using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Models;

namespace Application.Repositories
{
    public class CoursesRepository : IRepositoryAsync<Course>
    {
        public Task<int> CreateAsync(Course obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Course obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Course obj)
        {
            throw new NotImplementedException();
        }
    }
}
