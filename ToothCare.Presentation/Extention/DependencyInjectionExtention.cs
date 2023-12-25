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
            services.RegisterSingleton<ITreatmentRepository,TreatmentRepository>();
            services.RegisterSingleton<IDoctorRepository, DoctorRepository>();
            services.RegisterSingleton<IPatientRepository, PatientRepository>();
            services.RegisterSingleton<IAppointmentRepository, AppointmentRepository>();
            services.RegisterSingleton<IPaymentRepository, PaymentRepository>();

            //Register Services
            services.RegisterTransient<IRegisterService, RegisterService>();
            services.RegisterSingleton<IAuthService, AuthService>();
            services.RegisterSingleton<ITreatmentService, TreatmentService>();
            services.RegisterSingleton<IDoctorService, DoctorService>();
            services.RegisterSingleton<IPatientService, PatientService>();
            services.RegisterSingleton<IAppointmentService, AppointmentService>();
            services.RegisterSingleton<IPaymentService, PaymentService>();

            //Register Controllers
            services.RegisterTransient<HomeController>();
            services.RegisterTransient<RegisterController>();
            services.RegisterTransient<SignInController>();
            services.RegisterTransient<UserSessionController>();
            services.RegisterTransient<TreatmentController>();
            services.RegisterTransient<DoctorController>();
            services.RegisterTransient<PatientController>();
            services.RegisterTransient<AppointmentController>();

            return services;
        }


    }
}
