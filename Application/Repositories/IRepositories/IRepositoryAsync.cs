using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories.IRepositories
{
    public interface IRepositoryAsync<T>
    {
        public async Task<List<T>> GetAllAsync();
        public async Task<T> GetAsync(int id);
        public async Task<int> CreateAsync(T obj);
        public async Task<int> UpdateAsync(T obj);
        public async Task<int> DeleteAsync(int id);
    }
}
