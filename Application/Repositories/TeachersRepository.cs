using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Dal;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Application.Repositories
{
    public class TeachersRepository : IRepositoryAsync<Teacher>
    {
        private HighSchoolContext context;
        public TeachersRepository(HighSchoolContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Teacher obj)
        {
            await context.Teachers.AddAsync(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Teacher obj)
        {
            context.Teachers.Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllAsync() => await context.Teachers.ToListAsync();

        public async Task<Teacher> GetAsync(int id) => await context.Teachers.FirstOrDefaultAsync(t => t.ID == id);

        public async Task<int> UpdateAsync(Teacher obj)
        {
            var teacher = await GetAsync(obj.ID);
            teacher.LastName = obj.LastName;
            teacher.FirstName = obj.FirstName;
            teacher.Subjects = obj.Subjects;
            teacher.Email = obj.Email;
            teacher.BirthDate = obj.BirthDate;
            return await context.SaveChangesAsync();
        }
    }
}
