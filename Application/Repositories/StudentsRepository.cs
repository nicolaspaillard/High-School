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
        private HighSchoolContext _context;
        public StudentsRepository(HighSchoolContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(Student obj)
        {
            await _context.Students.AddAsync(obj);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Student obj)
        {
            var student = await _context.Students.FindAsync(obj.PersonID);          
            var grades = await _context.Grades.Where(g => g.StudentID == student.PersonID).ToListAsync(); //Suppression des notes associées à l'élève
            grades.ForEach(grade => _context.Grades.Remove(grade));        
            var missings = await _context.Missings.Where(m => m.StudentID == student.PersonID).ToListAsync(); //Suppression des absences associées à l'élève
            missings.ForEach(missing => _context.Missings.Remove(missing));        
            var groups = await _context.Groups.Where(g => g.HomeRoomTeacherID == student.PersonID).ToListAsync(); //Suppression de la liaison avec la table groups
            groups.ForEach(group => group.HomeRoomTeacherID = null);

            _context.Students.Remove(student);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync() => await _context.Students.ToListAsync();
        
        public async Task<Student> GetAsync(int id) => await _context.Students.FirstOrDefaultAsync(s => s.PersonID == id);

        public async Task<int> UpdateAsync(Student obj)
        {
            var temp = await GetAsync(obj.PersonID);
            temp.FirstName = obj.FirstName;
            temp.LastName = obj.LastName;
            temp.Email = obj.Email;
            temp.BirthDate = obj.BirthDate;
            temp.Grades = obj.Grades;
            return await _context.SaveChangesAsync();

        }
    }
}
