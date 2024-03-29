﻿using Dal;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class CourseApiRepository
    {
        private HighSchoolContext context;
        public CourseApiRepository(HighSchoolContext context)
        {
            this.context = context;
            context.ChangeTracker.LazyLoadingEnabled = false;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await context.Courses.AnyAsync() ? await context.Courses
                .Include(c => c.Teacher)
                //.Include(c => c.Classroom)
                .ToListAsync() : null;
        }

        public async Task<Course> GetAsync(int id)
        {
            return await context.Courses
                .Include(c => c.Groups).ThenInclude(g=>g.HomeRoomTeacher)
                .Include(c => c.Groups).ThenInclude(g => g.Students)
             
                .FirstOrDefaultAsync(c => c.CourseID == id);
        }
    }
}
