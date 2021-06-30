using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Dal;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Application.Repositories
{
    public class CoursesRepository : IRepositoryAsync<Course>
    {
        private HighSchoolContext context;
        public CoursesRepository(HighSchoolContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Course obj)
        {
            try
            {
                await context.Courses.AddAsync(obj);
                return await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }

        public async Task<int> DeleteAsync(Course obj)
        {
            context.Courses.Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllAsync() => await context.Courses.AnyAsync() ? await context.Courses.ToListAsync() : null;

        public async Task<Course> GetAsync(int id) => await context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);

        public Task<Course> GetAsync(Guid guid) => null;

        public async Task<int> UpdateAsync(Course obj)
        {
            try
            {
                var course = await GetAsync(obj.CourseID);
                course.Date = obj.Date;
                course.Missings = obj.Missings;
                course.Teacher = obj.Teacher;
                course.TeacherID = obj.TeacherID;
                course.Groups.Clear();
                course.Groups = obj.Groups;
                course.Classroom = obj.Classroom;
                course.ClassroomID = obj.ClassroomID;
                course.Subject = obj.Subject;
                course.SubjectID = obj.SubjectID;

                return await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }
    }
}
