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
        private HighSchoolContext _context;
        public TeachersRepository(HighSchoolContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(Teacher obj)
        {
            await _context.Teachers.AddAsync(obj);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Teacher obj)
        {
            var teacher = await _context.Teachers.FindAsync(obj.ID);
            var courses = await _context.Courses.Where(c => c.TeacherID == teacher.ID).ToListAsync();
            foreach (var course in courses)
            {
                course.TeacherID = null;
            }
         
            _context.Teachers.Remove(teacher);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllAsync() => await _context.Teachers.ToListAsync();

        public async Task<Teacher> GetAsync(int id) => await _context.Teachers.FirstOrDefaultAsync(t => t.ID == id);

        public async Task<int> UpdateAsync(Teacher obj)
        {
            var teacher = await GetAsync(obj.ID);
            teacher.LastName = obj.LastName;
            teacher.FirstName = obj.FirstName;
            teacher.Subjects = obj.Subjects;
            teacher.Email = obj.Email;
            teacher.BirthDate = obj.BirthDate;
            return await _context.SaveChangesAsync();
        }
    }
}
