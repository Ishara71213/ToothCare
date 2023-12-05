using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToothCare.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity() { 

        }
        private int Id { get; set; }
        private DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        private int? CreatedBy { get; set; }
        private DateTime? ModifiedOn { get; set; }
        private int? ModifiedBy { get; set; }
    }
}
