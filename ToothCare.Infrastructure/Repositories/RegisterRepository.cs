using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.Constatnts;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Infrastructure.Data;

namespace ToothCare.Infrastructure.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly DbContext _dbContext;
        public RegisterRepository(DbContext dbContext) 
        { 
            _dbContext = dbContext;
        }
        public async Task<Staff> RegisterUser(Staff user)
        {
            bool result= await _dbContext.WriteToFile<Staff>(DbFileNames.Staff, user);
            await _dbContext.GetAllFromFile<Staff>(DbFileNames.Staff);
            //await _dbContext.DeleteRcordById<Staff>(DbFileNames.Staff, 7);
            return result ? user : user;
        }

        public Task<bool> ValidateUser(Staff user)
        {
            throw new NotImplementedException();
        }
    }
}
