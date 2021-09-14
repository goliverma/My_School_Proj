using BAL.Repository;
using BAL.Repository.Interfaces;
using BAL.Repository.RepoClasses;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using Proj1.Models.Filter;
using Proj1.TokenAuthentication;

namespace Proj1
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
            services.AddControllersWithViews(options => {
                options.CacheProfiles.Add("ListCache",
                new CacheProfile()
                {
                    Duration = 30
                });
                options.Filters.Add(typeof(CustomExceptionFilter));
            });
            services.AddAuthentication("MyAuthCooki").AddCookie("MyAuthCooki", options => {
                options.Cookie.Name = "MyAuthCooki";
                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/User/AccessDenied";
            });
            services.AddSingleton<ITokenManager, TokenManager>();
            //services.AddSingleton<ILogger, Logger>();
            //services.AddScoped<CustomExceptionFilter>();
            services.AddTransient<ILinq, Linq>();
            services.AddTransient<IStudentRepo, StudentRepo>();
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddSession();
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
                //app.UseExceptionHandler("_Error");
            }
            app.UseDeveloperExceptionPage();

            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}
