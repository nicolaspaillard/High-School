using Application.Repositories.IRepositories;
using Dal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ClassroomsRepository : IRepositoryAsync<Classroom>
    {
        private HighSchoolContext context;
        public ClassroomsRepository(HighSchoolContext context)
        {
            this.context = context;
        }
        public Task<int> CreateAsync(Classroom obj)
        {
            context.Classrooms.AddAsync(obj);
            return await context.SaveChangesAsync();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Classroom>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Classroom> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Classroom obj)
        {
            throw new NotImplementedException();
        }
    }
}
