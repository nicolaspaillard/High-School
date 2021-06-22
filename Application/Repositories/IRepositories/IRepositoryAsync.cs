using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories.IRepositories
{
    public interface IRepositoryAsync<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(int id);
        public Task<T> GetAsync(Guid guid);
        public Task<int> CreateAsync(T obj);
        public Task<int> UpdateAsync(T obj);
        public Task<int> DeleteAsync(T obj);
    }
}
