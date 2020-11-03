using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet.DynamicInjector;
using DotNet.DynamicInjector.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UnitOfWork.BookStore.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            // Using EF Core
            services.AddScoped<UnitOfWork.BookStore.Data.EFCore.Context.DataContext>();
            
            var roles = new List<IoCRole>
            {
                new IoCRole
                {
                    Dll = "UnitOfWork.BookStore.Data.EFCore.dll", //DLL name
                    Implementation = "UnitOfWork.BookStore.Data.EFCore", // Implementation name, can be used for a control if you use several projects and wanted to separate them
                    Priority = 1, // Priority that the dll should be loaded
                    LifeTime = LifeTime.SCOPED, // Lifetime of your addiction injection
                    Name = "EF Core", //Dependency name. It is used only for identification
                    Active = true
                }
            };


            // Using Dapper
            // services.AddScoped<UnitOfWork.BookStore.Data.Dapper.Context.DataContext>();

            // var roles = new List<IoCRole>
            // {
            //     new IoCRole
            //     {
            //         Dll = "UnitOfWork.BookStore.Data.Dapper.dll", //DLL name
            //         Implementation = "UnitOfWork.BookStore.Data.Dapper", // Implementation name, can be used for a control if you use several projects and wanted to separate them
            //         Priority = 1, // Priority that the dll should be loaded
            //         LifeTime = LifeTime.SCOPED, // Lifetime of your addiction injection
            //         Name = "Dapper", //Dependency name. It is used only for identification
            //         Active = true
            //     }
            // };

            var allowedInterfaceNamespaces = new List<string> { "UnitOfWork" };

            var ioCConfiguration = new IoCConfiguration(roles, allowedInterfaceNamespaces);
            services.RegisterDynamicDependencies(ioCConfiguration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
