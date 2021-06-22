using Application.Repositories;
using Application.Repositories.IRepositories;
using Microsoft.Identity.Web;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Controllers.Tools
{
    public class AzureTools
    {
        private readonly StudentsRepository _students;
        private readonly TeachersRepository _teachers;

        public AzureTools(StudentsRepository students, TeachersRepository teachers)
        {
            _students = students;
            _teachers = teachers;
        }

        public async Task<Person> RegisterAzureUser(ClaimsPrincipal user)
        {
            var guidstr = user.Claims.FirstOrDefault(c => c.Type == ClaimConstants.ObjectId).Value;
            Guid guid;
            if (Guid.TryParse(guidstr, out guid))
            {
                var role = ((ClaimsIdentity)user.Identity).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                switch (role)
                {
                    case "Teacher":
                        var teacher = await _teachers.GetAsync(guid);
                        return teacher;
                    case "Student":
                        var student = await _students.GetAsync(guid);
                        return student;
                    //case "Administrator":
                    //    var admin = await _admins.GetAsync(guid);
                    //    return admin;
                    //    break;
                }
            }
            return null;
        }
    }
}
