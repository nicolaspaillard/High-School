﻿using System;
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
        public async Task<List<Group>> GetAllAsync() => await _context.Groups.AnyAsync() ? await _context.Groups.ToListAsync() : null;

        public async Task<Group> GetAsync(int id) => await _context.Groups.FirstOrDefaultAsync(g => g.GroupID == id);

        public Task<Group> GetAsync(Guid guid) => null;

        public async Task<int> UpdateAsync(Group obj)
        {
            try { 
            var group = await GetAsync(obj.GroupID);
            group.Students.Clear();
            group.Courses.Clear();
            group.Students = obj.Students;
            group.Courses = obj.Courses;
            group.HomeRoomTeacherID = obj.HomeRoomTeacherID;
            group.HomeRoomTeacher = obj.HomeRoomTeacher;
            return await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return -1;
            }
        }
        public async Task<int> UpdateAsyncGroup(Group obj, List<int> studentsID, List<int> coursesID)
        {
            var group = await GetAsync(obj.GroupID);
            var courses = new List<Course>();
            var students = new List<Student>();

            coursesID.ForEach(id => courses.Add(_context.Courses.FirstOrDefaultAsync(c => c.CourseID == id).Result));
            studentsID.ForEach(id => students.Add(_context.Students.FirstOrDefaultAsync(s => s.PersonID == id).Result));

            //group.Courses.ForEach(c => c.Groups.Clear());
            group.Courses.Clear();
            group.Courses = courses;
            group.Students = students;

            return await _context.SaveChangesAsync();
            /*var group = await GetAsync(obj.GroupID);
            group.Students = obj.Students;
            group.Courses = obj.Courses;
            group.HomeRoomTeacherID = obj.HomeRoomTeacherID;
            group.HomeRoomTeacher = obj.HomeRoomTeacher;
            return await _context.SaveChangesAsync();*/
        }
    }
}
