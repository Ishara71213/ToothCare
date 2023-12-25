using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Builders
{
    public class UserBuilder : BaseEntityBuilder
    {
        protected string firstName = string.Empty;
        protected string lastName = string.Empty;
        protected string email = string.Empty;
        protected string encryptedPassword = string.Empty;
        protected string mobileNo = string.Empty;
        protected string address = string.Empty;

        public UserBuilder()
        {

        }

        public UserBuilder(string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address)
            : base()
        {

            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.encryptedPassword = encryptedPassword;
            this.mobileNo = mobileNo;
            this.address = address;
        }
        public UserBuilder(int id, string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address)
            : base(id)
        {

            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.encryptedPassword = encryptedPassword;
            this.mobileNo = mobileNo;
            this.address = address;
        }


        public override User Build()
        {
            return new User(id, createdOn, createdBy, modifiedOn, modifiedBy, firstName, lastName, email, encryptedPassword, mobileNo, address);
            
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public void SetEncryptedPassword(string encryptedPassword)
        {
            this.encryptedPassword = encryptedPassword;
        }

        public void SetMobileNo(string mobileNo)
        {
            this.mobileNo = mobileNo;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

    }
}
