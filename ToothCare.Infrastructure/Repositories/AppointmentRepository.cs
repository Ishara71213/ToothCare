using ECCMS.Infrastructure.Repositories;
using ToothCare.Domain.Constatnts;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Infrastructure.Data;

namespace ToothCare.Infrastructure.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DbContext dbContext) : base(dbContext, DbFileNames.Appointments)
        { 
        }
       

    }
}
