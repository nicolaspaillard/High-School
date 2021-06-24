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
    public class GradesRepository : IRepositoryAsync<Grade>
    {
        private HighSchoolContext context;
        public GradesRepository(HighSchoolContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Grade obj)
        {
            await context.Grades.AddAsync(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Grade obj)
        {
            context.Grades.Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Grade>> GetAllAsync() => await context.Grades.AnyAsync() ? await context.Grades.ToListAsync() : null;


        public async Task<Grade> GetAsync(int id) => await context.Grades.FirstOrDefaultAsync(g => g.GradeID == id);

        public Task<Grade> GetAsync(Guid guid) => null;

        public async Task<int> UpdateAsync(Grade obj)
        {
            var grade = await GetAsync(obj.GradeID);
            grade.Assessment = obj.Assessment;
            grade.Course = obj.Course;
            grade.Student = obj.Student;
            grade.Value = obj.Value;
            return await context.SaveChangesAsync();
        }
    }
}
