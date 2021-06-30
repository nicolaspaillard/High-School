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
    public class MissingsRepository : IRepositoryAsync<Missing>
    {
        private HighSchoolContext context;
        public MissingsRepository(HighSchoolContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Missing obj)
        {

            context.Missings.Add(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Missing obj)
        {
            
            context.Missings.Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Missing>> GetAllAsync() => await context.Missings.AnyAsync() ? await context.Missings.ToListAsync() : null;

        public async Task<Missing> GetAsync(int id) => await context.Missings.FirstOrDefaultAsync(m => m.MissingID == id);

        public Task<Missing> GetAsync(Guid guid) => null;
        public async Task<int> UpdateAsync(Missing obj)
        {
            var missing = await GetAsync(obj.MissingID);
            missing.MissingID = obj.MissingID;
            missing.StudentID = obj.StudentID;
            missing.Student = obj.Student;
            missing.CourseID = obj.CourseID;
            missing.Course = obj.Course;
            return await context.SaveChangesAsync();
        }
    }
}
