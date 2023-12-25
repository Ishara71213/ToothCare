using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToothCare.Domain.Interfaces.Common;

namespace ToothCare.Domain.Entities
{
    public class User : BaseEntity, IJsonConvertible<User>
    {
        public string firstName= string.Empty;
        public string lastName = string.Empty;
        protected string email= string.Empty;
        private string encryptedPassword = string.Empty;
        protected string mobileNo= string.Empty;
        protected string address = string.Empty;

        public User()
        {

        }

        public User(string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address)
            : base()
        {

            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.encryptedPassword = encryptedPassword;
            this.mobileNo = mobileNo;
            this.address = address;
        }
        public User(int id, string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address)
            : base(id)
        {

            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.encryptedPassword = encryptedPassword;
            this.mobileNo = mobileNo;
            this.address = address;
        }

        public User(int id, DateTime? createdOn, int? createdBy, DateTime? modifiedOn, int? modifiedBy, string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address) 
            : base(id, createdOn, createdBy, modifiedBy, modifiedOn)
        {

            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.encryptedPassword = encryptedPassword;
            this.mobileNo = mobileNo;
            this.address = address;
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetEmail()
        {
            return this.email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEncryptedPassword()
        {
            return this.encryptedPassword;
        }

        public void SetEncryptedPassword(string encryptedPassword)
        {
            this.encryptedPassword = encryptedPassword;
        }

        public string GetMobileNo()
        {
            return this.mobileNo;
        }

        public void SetMobileNo(string mobileNo)
        {
            this.mobileNo = mobileNo;
        }

        public string GetAddress()
        {
            return this.address;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public override string ToString()
        {
            string resultBase = $"\"id\":\"{this.id}\", \"createdOn\":\"{this.createdOn}\", \"createdBy\":\"{this.createdBy}\", \"modifiedOn\":\"{this.modifiedOn}\", \"modifiedBy\":\"{this.modifiedBy}\", ";
            string resultUser = $"\"firstName\":\"{this.firstName}\", \"lastName\":\"{this.lastName}\", \"email\":\"{this.email}\", \"encryptedPassword\":\"{this.GetEncryptedPassword()}\", \"mobileNo\":\"{this.mobileNo}\", \"address\":\"{this.address}\"";

            string result = "{" + resultBase + resultUser + "}";
            return result;
        }

        public override User FromJson(string json)
        {
            if (!json.Contains("id"))
            {
                return new User();
            }

            dynamic jsonData = JsonConvert.DeserializeObject(json)!;
            User user = new User(jsonData.id, jsonData.createdOn, jsonData.createdBy, jsonData.modifiedOn, jsonData.modifiedBy, jsonData.firstName, jsonData.lastName, jsonData.email, jsonData.encryptedPassword, jsonData.mobileNo, jsonData.address);
            return user;
        }
    }
}
