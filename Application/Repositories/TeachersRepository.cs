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
            var teacher = await context.Teachers.FindAsync(obj.PersonID);
            var courses = await context.Courses.Where(c => c.TeacherID == teacher.PersonID).ToListAsync();
            foreach (var course in courses)
            {
                course.TeacherID = null;
            }
         
            context.Teachers.Remove(teacher);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllAsync() => await context.Teachers.AnyAsync() ? await context.Teachers.ToListAsync() : null;

        public async Task<Teacher> GetAsync(int id) => await context.Teachers.FirstOrDefaultAsync(t => t.PersonID == id);
        public async Task<Teacher> GetAsync(Guid guid) => await context.Teachers.FirstOrDefaultAsync(t => t.AzureID == guid);

        public async Task<int> UpdateAsync(Teacher obj)
        {
            var teacher = await GetAsync(obj.PersonID);
            teacher.LastName = obj.LastName;
            teacher.FirstName = obj.FirstName;
            teacher.Subjects = obj.Subjects;
            teacher.Email = obj.Email;
            teacher.BirthDate = obj.BirthDate;
            return await context.SaveChangesAsync();
        }
    }
}
