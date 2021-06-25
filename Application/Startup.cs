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
using Models;
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
            //services.AddScoped<IRepositoryAsync<Group>, GroupsRepository>();
            services.AddScoped<IRepositoryAsync<Missing>, MissingsRepository>();
            services.AddScoped<IRepositoryAsync<Subject>, SubjectsRepository>();
            services.AddScoped<GroupsRepository>();
            services.AddTransient<TeachersService>();
            services.AddTransient<StudentsRepository>();
            services.AddTransient<SubjectsService>();
            services.AddTransient<ClassroomsService>();
            services.AddTransient<CoursesService>();
            services.AddTransient<StudentsService>();
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
            }).AddRazorRuntimeCompilation();
            services.AddRazorPages().AddMicrosoftIdentityUI();
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
