﻿using Application.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.Services
{
    public class RepositoryService<T>
    {
        private readonly IRepositoryAsync<T> _repository;
        public RepositoryService(IRepositoryAsync<T> repository)
        {
            _repository = repository;
        }
        public async Task<List<T>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<T> GetAsync(int id) => await _repository.GetAsync(id);
    }
}
