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
    public class AdminsRepository : IRepositoryAsync<Administrator>
    {
        private HighSchoolContext context;
        public AdminsRepository(HighSchoolContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(Administrator obj)
        {
            await context.Admins.AddAsync(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Administrator obj)
        {
            context.Admins.Remove(obj);
            return await context.SaveChangesAsync();
        }

        public async Task<List<Administrator>> GetAllAsync() => await context.Admins.ToListAsync();

        public async Task<Administrator> GetAsync(int id) => await context.Admins.FirstOrDefaultAsync(s => s.PersonID == id);

        public async Task<Administrator> GetAsync(Guid guid) => await context.Admins.FirstOrDefaultAsync(s => s.AzureID == guid);
        public async Task<int> UpdateAsync(Administrator obj)
        {
            var admin = await GetAsync(obj.PersonID);
            admin.LastName = obj.LastName;
            admin.FirstName = obj.FirstName;
            admin.Email = obj.Email;
            admin.BirthDate = obj.BirthDate;
            return await context.SaveChangesAsync();
        }
    }
}
