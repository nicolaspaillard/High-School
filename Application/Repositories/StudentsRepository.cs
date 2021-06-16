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
    public class StudentsRepository : IRepositoryAsync<Student>
    {
        private HighSchoolContext context;
        public StudentsRepository(HighSchoolContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Student obj)
        {
            await context.Students.AddAsync(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Student obj)
        {
            context.Students.Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<Student> GetAsync(int id)
        {
            return await context.Students.FirstOrDefaultAsync(s => s.ID == id);
        }

        public Task<int> UpdateAsync(Student obj)
        {
            var temp = GetAsync(obj.ID);

        }
    }
}
