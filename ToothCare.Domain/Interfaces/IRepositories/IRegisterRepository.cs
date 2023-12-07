using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Interfaces.IRepositories
{
    public interface IRegisterRepository
    {
        public Task<bool> ValidateUser(Staff user);

        public Task<Staff> RegisterUser(Staff user);
    }
}
