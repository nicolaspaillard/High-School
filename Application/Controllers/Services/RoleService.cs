using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Controllers.Services
{
    public class RoleService
    {
        public async Task<Role> GetRoleAsync(ClaimsPrincipal user)
        {
            var role = ((ClaimsIdentity)user.Identity).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            Role ret = 0;
            switch (role)
            {
                case "Administrator": ret = Role.Admin; break;
                case "Teacher": ret = Role.Teacher; break;
                case "Student": ret = Role.Student; break;
            }
            return ret;
        }
    }
}
