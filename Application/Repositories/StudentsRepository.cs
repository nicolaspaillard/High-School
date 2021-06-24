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
        public async Task<List<Student>> GetAllAsync() => await context.Students.AnyAsync() ? await context.Students.ToListAsync() : null; 
        public async Task<Student> GetAsync(int id) => await context.Students.FirstOrDefaultAsync(s => s.PersonID == id);

        public async Task<Student> GetAsync(Guid id) => await context.Students.FirstOrDefaultAsync(s => s.AzureID == id);

        public async Task<int> UpdateAsync(Student obj)
        {
            var temp = await GetAsync(obj.PersonID);
            temp.FirstName = obj.FirstName;
            temp.LastName = obj.LastName;
            temp.Email = obj.Email;
            temp.BirthDate = obj.BirthDate;
            temp.Grades = obj.Grades;
            return await context.SaveChangesAsync();

        }
    }
}
