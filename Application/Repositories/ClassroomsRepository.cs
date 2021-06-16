using Application.Repositories.IRepositories;
using Dal;
using Microsoft.EntityFrameworkCore;
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
        public async Task<int> CreateAsync(Classroom obj)
        {
            await context.Classrooms.AddAsync(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Classroom obj)
        {
            context.Classrooms.Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Classroom>> GetAllAsync()
        {
            return await context.Classrooms.ToListAsync();
        }

        public async Task<Classroom> GetAsync(int id)
        {
            return await context.Classrooms.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<int> UpdateAsync(Classroom obj)
        {
            context.Classrooms.First(m => m.ID == obj.ID).ID = obj.ID;
            context.Classrooms.First(m => m.ID == obj.ID).Name = obj.Name;
            return await context.SaveChangesAsync();
        }
    }
}
