using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Application.Controllers.ViewComponents
{
    public class MissingsListViewComponents : ViewComponent
    {
        private readonly IRepositoryAsync<Missing> _repository;

        public MissingsListViewComponents(IRepositoryAsync<Missing> repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<Missing> missings)
        {
            //var missings = await GetMissingsByStudentId(id);
            return View(missings);
        }

        private async Task<List<Missing>> GetMissingsByStudentId(int? id)
        {
            var missings = await _repository.GetAllAsync();
            return missings.Where(m => m.StudentID == id).ToList();
        }
    }
}
