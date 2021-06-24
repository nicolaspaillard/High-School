using Application.Models;
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
        private readonly IRepositoryAsync<Student> _students;
        private readonly IRepositoryAsync<Teacher> _teachers;
        private readonly IRepositoryAsync<Admin> _admins;

        public AzureTools(IRepositoryAsync<Student> students, IRepositoryAsync<Teacher> teachers, IRepositoryAsync<Admin> admins)
        {
            _students = students;
            _teachers = teachers;
            _admins = admins;
        }
        //  RegisterAzureUser(User);
        //  Permet de récupérer dans la base de données l'objet Person
        //  associé au Guid récupéré dans les Claims azure de la personne
        //  venant de se connecter (User)
        //  Cet objet Person sera du type récupéré dans le Claim "Role",
        //  et si aucun Role n'est défini il ne sera pas ajouté à la base
        public async Task<Person> RegisterAzureUser(ClaimsPrincipal azurePersonClaims)
        {
            //  Récupération et validation du Guid
            if (!Guid.TryParse(azurePersonClaims.Claims.FirstOrDefault(c => c.Type == ClaimConstants.ObjectId).Value, out Guid azurePersonGuid))
            {
                return null;
            }
            else
            {
                //  Récupération et traitement du rôle
                var azurePersonRole = ((ClaimsIdentity)azurePersonClaims.Identity).Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
                switch (azurePersonRole)
                {
                    case "Administrator":
                        //  Récupération des infos utilisateur dans les Claims
                        Admin admin = new()
                        {
                            Email = azurePersonClaims.FindFirst("preferred_username").Value,
                            FirstName = azurePersonClaims.FindFirst("name").Value.Split('_').First()[0].ToString().ToUpper() + azurePersonClaims.FindFirst("name").Value.Split('_').First().Substring(1).ToLower(),
                            LastName = azurePersonClaims.FindFirst("name").Value.Split('_').Last().ToUpper(),
                            AzureID = azurePersonGuid,
                            Role = Role.Admin
                        };
                        admin = await GetPerson(_admins, admin, azurePersonClaims, azurePersonGuid);
                        return admin;
                    case "Teacher":
                        //  Récupération des infos utilisateur dans les Claims
                        Teacher teacher = new()
                        {
                            Email = azurePersonClaims.FindFirst("preferred_username").Value,
                            FirstName = azurePersonClaims.FindFirst("name").Value.Split('_').First()[0].ToString().ToUpper() + azurePersonClaims.FindFirst("name").Value.Split('_').First().Substring(1).ToLower(),
                            LastName = azurePersonClaims.FindFirst("name").Value.Split('_').Last().ToUpper(),
                            AzureID = azurePersonGuid,
                            Role = Role.Teacher
                        };
                        teacher = await GetPerson(_teachers, teacher, azurePersonClaims, azurePersonGuid);
                        return teacher;
                    case "Student":
                        Student student = new()
                        {
                            Email = azurePersonClaims.FindFirst("preferred_username").Value,
                            FirstName = azurePersonClaims.FindFirst("name").Value.Split('_').First()[0].ToString().ToUpper() + azurePersonClaims.FindFirst("name").Value.Split('_').First().Substring(1).ToLower(),
                            LastName = azurePersonClaims.FindFirst("name").Value.Split('_').Last().ToUpper(),
                            AzureID = azurePersonGuid,
                            Role = Role.Student
                        };
                        student = await GetPerson(_students, student, azurePersonClaims, azurePersonGuid);
                        return student;
                    default:
                        //ATTENTION personne non ajoutée par défaut si aucun rôle défini !
                        return null;
                }
            } 
        }
        //  Récupère la personne connectée en base si
        //  elle existe, l'y ajoute si elle n'exsiste pas,
        //  puis la retourne   
        private static async Task<T> GetPerson<T>(IRepositoryAsync<T> repository, T azurePerson, ClaimsPrincipal user, Guid azurePersonGuid) where T : Person
        {
            T appPerson = await repository.GetAsync(azurePersonGuid);            
            if (appPerson == null)
            {
                await repository.CreateAsync(azurePerson);
                appPerson = azurePerson;
            }
            return appPerson;
        }
    }
}
