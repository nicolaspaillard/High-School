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
    public class SubjectsRepository : IRepositoryAsync<Subject>
    {
        private HighSchoolContext context;
        public SubjectsRepository(HighSchoolContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Subject obj)
        {
            await context.Subjects.AddAsync(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Subject obj)
        {
            context.Subjects.Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetAllAsync() => await context.Subjects.AnyAsync() ? await context.Subjects.ToListAsync() : null; 

        public async Task<Subject> GetAsync(int id) => await context.Subjects.FirstOrDefaultAsync(s => s.SubjectID == (SubjectMatter)id);

        public Task<Subject> GetAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Subject obj)
        {
            return await context.SaveChangesAsync();
        }
    }
}
