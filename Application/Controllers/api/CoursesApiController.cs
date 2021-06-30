using Application.Repositories;
using Application.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers.api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesApiController : ControllerBase
    {
        private readonly CourseApiRepository _repository;

        public CoursesApiController(CourseApiRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await _repository.GetAllAsync());
        }


        // api/CoursesApi/getcourse/2

        [HttpGet("course/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var course = await _repository.GetAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

    }
}
