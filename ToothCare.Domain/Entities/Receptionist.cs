using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToothCare.Domain.Entities
{
    public class Staff : User
    {
        public string Designation { get; set; } = null!;
    }
}
