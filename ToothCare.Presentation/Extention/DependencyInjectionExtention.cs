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

            //Register Repositories
            services.RegisterTransient<IRegisterRepository,RegisterRepository>();
            services.RegisterSingleton<IAuthRepository,AuthRepository>();

            //Register Services
            services.RegisterTransient<IRegisterService, RegisterService>();
            services.RegisterSingleton<IAuthService, AuthService>();

            //Register Controllers
            services.RegisterTransient<HomeController>();
            services.RegisterTransient<RegisterController>();
            services.RegisterTransient<SignInController>();
            services.RegisterTransient<UserSessionController>();

            return services;
        }


    }
}
