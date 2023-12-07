using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToothCare.Domain.Entities
{
    public class Patient : User
    {
        public string Illness { get; set; } = null!;
        public string Alergies { get; set; } = null!;
        public string EmergencyContact { get; set; } = null!;
    }
}
