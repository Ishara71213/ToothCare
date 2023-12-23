using ECCMS.Infrastructure.Repositories;
using ToothCare.Domain.Constatnts;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Infrastructure.Data;

namespace ToothCare.Infrastructure.Repositories
{
    public class AuthRepository : GenericRepository<Staff>, IAuthRepository
    {
        private readonly DbContext _dbContext;
        public AuthRepository(DbContext dbContext) : base(dbContext, DbFileNames.Staff)
        { 
            _dbContext = dbContext;
        }
       

    }
}
