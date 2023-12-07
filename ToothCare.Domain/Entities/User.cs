using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToothCare.Domain.Entities
{
    public class User : BaseEntity
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string EncryptedPassword { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
