using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Interfaces.IServices
{
    public interface IAuthService
    {
        public Task<Staff> SignIn(string email, string password);

        public void SignOut();

        public bool IsAuthenticated();

        public Staff? GetCurrentUser();

        public Task<Staff> SetCurrentUser(Staff staff);
    }
}
