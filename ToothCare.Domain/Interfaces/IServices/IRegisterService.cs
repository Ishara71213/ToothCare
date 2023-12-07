using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Interfaces.IServices
{
    public interface IRegisterService
    {
        public Task<bool> ValidateUser(Staff user);

        public Task<Staff> RegisterUser(Staff user);
    }
}
