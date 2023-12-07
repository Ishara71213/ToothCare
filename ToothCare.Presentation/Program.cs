using Microsoft.AspNetCore.Mvc.Controllers;
using ToothCare.Application.Services;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Domain.IocFramework;
using ToothCare.Infrastructure.Repositories;
using ToothCare.Presentation.Areas.Auth.Controllers;
using ToothCare.Presentation.Controllers;
using ToothCare.Presentation.Extention;

namespace ToothCare.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //var services= new DiServiceCollection();
            var services= DependencyInjectionExtention.GetRegsiteredDependencies();
            
            var container = services.GenerateContainer();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".ToothCarePortal.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(120);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Register the Custom DiControllerActivator
            builder.Services.AddSingleton<IControllerActivator>(provider =>
                new DiControllerActivator(container));
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseRouteGuard();
            app.UseHandleEndpointRouting();

            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
            });*/
            /*app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");*/

            app.Run();
        }
    }
}