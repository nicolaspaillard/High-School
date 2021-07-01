using Application.Controllers.Services;
using Application.Repositories;
using Application.Repositories.IRepositories;
using Dal;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.OpenApi.Models;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepositoryAsync<Student>, StudentsRepository>();
            services.AddScoped<IRepositoryAsync<Teacher>, TeachersRepository>();
            services.AddScoped<IRepositoryAsync<Admin>, AdminsRepository>();
            services.AddScoped<IRepositoryAsync<Classroom>, ClassroomsRepository>();
            services.AddScoped<IRepositoryAsync<Course>, CoursesRepository>();
            services.AddScoped<IRepositoryAsync<Grade>, GradesRepository>();
            services.AddScoped<IRepositoryAsync<Group>, GroupsRepository>();
            services.AddScoped<IRepositoryAsync<Missing>, MissingsRepository>();
            services.AddScoped<IRepositoryAsync<Subject>, SubjectsRepository>();
            services.AddTransient<RepositoryService<Student>>();
            services.AddTransient<RepositoryService<Teacher>>();
            services.AddTransient<RepositoryService<Admin>>();
            services.AddTransient<RepositoryService<Group>>();
            services.AddTransient<RepositoryService<Grade>>();
            services.AddTransient<RepositoryService<Missing>>();
            services.AddTransient<RepositoryService<Subject>>();
            services.AddTransient<RepositoryService<Course>>();
            services.AddTransient<RepositoryService<Classroom>>();
            services.AddTransient<RoleService>();
            services.AddTransient<CourseApiRepository>();
          
            services.AddDbContext<HighSchoolContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("HighSchoolDb"))
            );
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));
            services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddRazorRuntimeCompilation().AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddRazorPages().AddMicrosoftIdentityUI();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
