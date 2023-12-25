using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Builders
{
    public class StaffBuilder : UserBuilder
    {
        private string designation = string.Empty;

        public StaffBuilder() { }
        public StaffBuilder(string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string designation)
            : base(firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.designation = designation;
        }

        public StaffBuilder(int id, string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string designation)
            : base(id, firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.designation = designation;
        }


        public override Staff Build()
        {
            return new Staff(id, createdOn, createdBy, modifiedOn, modifiedBy, firstName, lastName, email, encryptedPassword, mobileNo, address, designation);
        }

        public StaffBuilder SetDesignation(string designation)
        {
            this.designation = designation;
            return this;
        }
    }
}
