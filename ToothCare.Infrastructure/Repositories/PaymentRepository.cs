using ECCMS.Infrastructure.Repositories;
using ToothCare.Domain.Constatnts;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Infrastructure.Data;

namespace ToothCare.Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DbContext dbContext) : base(dbContext, DbFileNames.Payments)
        { 
        }
       

    }
}
