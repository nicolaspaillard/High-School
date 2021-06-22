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
        private HighSchoolContext _context;
        public SubjectsRepository(HighSchoolContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(Subject obj)
        {
            await _context.Subjects.AddAsync(obj);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Subject obj)
        {
            var subject = await _context.Subjects.FindAsync(obj.SubjectID);
            var courses = await _context.Courses.Where(c => c.SubjectID == subject.SubjectID).ToListAsync();
            foreach (var course in courses)
            {
                course.SubjectID = null;
            }
            _context.Subjects.Remove(subject);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetAllAsync() => await _context.Subjects.ToListAsync();

        public async Task<Subject> GetAsync(int id) => await _context.Subjects.FindAsync((SubjectMatter)id);

        public async Task<int> UpdateAsync(Subject obj)
        {
            return await _context.SaveChangesAsync();
        }
    }
}
