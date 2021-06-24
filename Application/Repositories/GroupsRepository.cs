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
        private HighSchoolContext _context;
        public GroupsRepository(HighSchoolContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(Group obj)
        {
            await _context.Groups.AddAsync(obj);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Group obj)
        {
            _context.Groups.Remove(obj);
            return await _context.SaveChangesAsync();
        }
        public async Task<List<Group>> GetAllAsync() => await _context.Groups.ToListAsync();

        public async Task<Group> GetAsync(int id) => await _context.Groups.FirstOrDefaultAsync(g => g.GroupID == id);

        public Task<Group> GetAsync(Guid guid) => null;

        public async Task<int> UpdateAsync(Group obj)
        {
            var group = await GetAsync(obj.GroupID);
            group.Students = obj.Students;
            group.Courses = obj.Courses;
            group.HomeRoomTeacherID = obj.HomeRoomTeacherID;
            group.HomeRoomTeacher = obj.HomeRoomTeacher;
            return await _context.SaveChangesAsync();
        }
    }
}
