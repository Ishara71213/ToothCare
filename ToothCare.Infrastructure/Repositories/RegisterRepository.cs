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
            if (!result) throw new Exception("Something Went Wrong");
            return user;
        }

        public async Task<bool> ValidateUser(Staff user)
        {
            CustomLinkedList<Staff>? staffList = await _dbContext.GetAllFromFile<Staff>(DbFileNames.Staff);
            
            if (staffList == null) return true;

            Staff? search=  staffList!.Where(x=>x.MobileNo==user.MobileNo || x.Email == user.Email).FirstOrDefault();

            if (search != null)
            {
                if (search.MobileNo == user.MobileNo) throw new Exception("Mobile No Already Exist");

                if (search.Email == user.Email) throw new Exception("Email Already Exist");
            }
            return true;

        }
    }
}
