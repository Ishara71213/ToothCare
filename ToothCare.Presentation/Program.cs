using Microsoft.AspNetCore.Mvc.Controllers;
using ToothCare.Application.Services;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Domain.IocFramework;
using ToothCare.Infrastructure.Repositories;
using ToothCare.Presentation.Controllers;
using ToothCare.Presentation.Extention;

namespace ToothCare.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services= new DiServiceCollection();
            //services.RegisterSingleton<RandomGuidGenerator>();
            services.RegisterSingleton<IServiceOne,ServiceOne>();
            services.RegisterSingleton<IRandomGuidRepository, RandomGuidRepository>();
            services.RegisterTransient<HomeController>();

            
            var container = services.GenerateContainer();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}