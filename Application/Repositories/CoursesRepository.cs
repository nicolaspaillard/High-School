﻿using System;
using System.Collections.Generic;
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
            await context.Courses.AddAsync(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Course obj)
        {
            context.Courses.Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllAsync() => await context.Courses.ToListAsync();

        public async Task<Course> GetAsync(int id) => await context.Courses.FirstOrDefaultAsync(c => c.ID == id);

        public async Task<int> UpdateAsync(Course obj)
        {
            var course = await GetAsync(obj.ID);

            course.Date = obj.Date;
            course.Classroom = obj.Classroom;
            course.Missings = obj.Missings;
            course.Groups = obj.Groups;
            course.Subject = obj.Subject;
            course.Teacher = obj.Teacher;

            return await context.SaveChangesAsync();
        }
    }
}