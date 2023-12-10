using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.Constatnts;
using ToothCare.Domain.DataStructures;
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
            Staff? entity;
            CustomLinkedList<Staff>? staffList = await _dbContext.GetAllFromFile<Staff>(DbFileNames.Staff);

            if (staffList != null )
            {
                entity = staffList.Where((e)=> e.Email == user.Email).GetFirst();
                
                if (entity != null )
                { 
                    user.IsExist = true;
                    return user;
                }
            }

            bool result = await _dbContext.WriteToFile<Staff>(DbFileNames.Staff, user);
            //await _dbContext.DeleteRcordById<Staff>(DbFileNames.Staff, 7);
            if (!result) throw new Exception("Something Went Wrong");
            return user;
        }

        public Task<bool> ValidateUser(Staff user)
        {
            throw new NotImplementedException();
        }
    }
}
