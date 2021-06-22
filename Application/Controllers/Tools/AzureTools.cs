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
    public static class AzureTools
    {
        public static IEnumerable<string> RegisterAzureUser(ClaimsPrincipal user)
        {
            //var currentId = user.Claims.FirstOrDefault(c => c.Type == ClaimConstants.ObjectId.ToString()).Value;
            //var role = user.Claims.FirstOrDefault(c => c.Type == ClaimConstants.Role.ToString()).Value;
            var roles = ((ClaimsIdentity)user.Identity).Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            return roles;        
        }
    }
}
