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

        public async Task<List<Classroom>> GetAllAsync() => await context.Classrooms.AnyAsync() ? await context.Classrooms.ToListAsync() : null;

        public async Task<Classroom> GetAsync(int id) => await context.Classrooms.FirstOrDefaultAsync(c => c.ClassroomID == id);

        public Task<Classroom> GetAsync(Guid guid) => null;

        public async Task<int> UpdateAsync(Classroom obj)
        {
            var classroom = await GetAsync(obj.ClassroomID);
            classroom.ClassroomID = obj.ClassroomID;
            classroom.Name = obj.Name;
            return await context.SaveChangesAsync();
        }
    }
}
