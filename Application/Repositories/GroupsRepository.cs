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
    public class GroupsRepository : IRepositoryAsync<Group>
    {
        private HighSchoolContext context;
        public GroupsRepository(HighSchoolContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Group obj)
        {
            await context.Groups.AddAsync(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Group obj)
        {
            context.Groups.Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Group>> GetAllAsync() => await context.Groups.ToListAsync();

        public async Task<Group> GetAsync(int id) => await context.Groups.FirstOrDefaultAsync(g => g.ID == id);

        public async Task<int> UpdateAsync(Group obj)
        {
            var group = await GetAsync(obj.ID);
            group.Students = obj.Students;
            group.Courses = obj.Courses;
            group.HomeRoomTeacher = obj.HomeRoomTeacher;
            return await context.SaveChangesAsync();
        }
    }
}
