using ToothCare.Application.Services;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Domain.IocFramework;
using ToothCare.Infrastructure.Data;
using ToothCare.Infrastructure.Repositories;
using ToothCare.Presentation.Areas.Auth.Controllers;
using ToothCare.Presentation.Controllers;

namespace ToothCare.Presentation.Extention
{
    public static class DependencyInjectionExtention
    {
        public static DiServiceCollection GetRegsiteredDependencies()
        {
            var services = new DiServiceCollection();
            services.RegisterSingleton<DbContext>();
            services.RegisterSingleton<IServiceOne, ServiceOne>();
            services.RegisterSingleton<IRandomGuidRepository, RandomGuidRepository>();

            //Register Repositories
            services.RegisterTransient<IRegisterRepository,RegisterRepository>();

            //Register Services
            services.RegisterTransient<IRegisterService, RegisterService>();
            //Register Controllers
            services.RegisterTransient<HomeController>();
            services.RegisterTransient<RegisterController>();
            services.RegisterTransient<SignInController>();

            return services;
        }


    }
}
