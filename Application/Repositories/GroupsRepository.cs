using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Models;

namespace Application.Repositories
{
    public class GroupsRepository : IRepositoryAsync<Group>
    {
        public Task<int> CreateAsync(Group obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Group obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Group obj)
        {
            throw new NotImplementedException();
        }
    }
}
