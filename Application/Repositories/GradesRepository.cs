using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Models;

namespace Application.Repositories
{
    public class GradesRepository : IRepositoryAsync<Grade>
    {
        public Task<int> CreateAsync(Grade obj)
        {
            //araerfezat
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Grade obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Grade>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Grade> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Grade obj)
        {
            throw new NotImplementedException();
        }
    }
}
