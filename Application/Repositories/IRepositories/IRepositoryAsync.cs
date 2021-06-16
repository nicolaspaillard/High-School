using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories.IRepositories
{
    public interface IRepositoryAsync<T>
    {
<<<<<<< HEAD
        public  Task<List<T>> GetAllAsync();
        public  Task<T> GetAsync(int id);
        public  Task<int> CreateAsync(T obj);
        public  Task<int> UpdateAsync(T obj);
=======
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(int id);
        public Task<int> CreateAsync(T obj);
        public Task<int> UpdateAsync(T obj);
>>>>>>> f787d2a1396d75c6dd92a7f681d61d28e1c1831d
        public Task<int> DeleteAsync(T obj);
    }
}
