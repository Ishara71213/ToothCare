using Newtonsoft.Json;
using ToothCare.Domain.Builders;
using ToothCare.Domain.Interfaces.Common;

namespace ToothCare.Domain.Entities
{
    public class Staff : User, IJsonConvertible<Staff>
    {
        internal string designation=string.Empty;
        
        public Staff() { }

        //Constructors internal because object creation is centerlized into the Builders
        // these constructors will not be used in other Assemblies
        internal Staff(string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string designation)
            : base( firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.designation = designation;
        }

        internal Staff(int id,  string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string designation)
            : base(id, firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.designation = designation;
        }

        internal Staff(int id, DateTime? createdOn, int? createdBy, DateTime? modifiedOn, int? modifiedBy, string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string designation)
            : base(id, createdOn, createdBy, modifiedOn, modifiedBy, firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.designation = designation;
        }

        public string GetDesignation()
        {
            return this.designation;
        }

        public void SetDesignation(string designation)
        {
            this.designation = designation;
        }

        //overides the to string and generate string as json format
        public override string ToString()
        {   
            string resultBase= $"\"id\":\"{this.id}\", \"createdOn\":\"{this.createdOn}\", \"createdBy\":\"{this.createdBy}\", \"modifiedOn\":\"{this.modifiedOn}\", \"modifiedBy\":\"{this.modifiedBy}\", ";
            string resultUser= $"\"firstName\":\"{this.firstName}\", \"lastName\":\"{this.lastName}\", \"email\":\"{this.email}\", \"encryptedPassword\":\"{this.GetEncryptedPassword()}\", \"mobileNo\":\"{this.mobileNo}\", \"address\":\"{this.address}\", ";
            string resultStaff= $"\"designation\":\"{this.designation}\"";

            string result = "{" + resultBase + resultUser + resultStaff + "}";
            return result;
        }

        //From json method will create Instance from the corresponding json string
        public override Staff FromJson(string json)
        {
            if (!json.Contains("id"))
            {
                return new Staff();
            }

            dynamic jsonData = JsonConvert.DeserializeObject(json)!;

            int id = jsonData.id != "" ? jsonData.id : 0;
            DateTime? createdOn = jsonData.createdOn != "" ? jsonData.createdOn : null;
            DateTime? modifiedOn = jsonData.modifiedOn != "" ? jsonData.modifiedOn : null;
            int? createdBy = jsonData.createdBy != "" ? jsonData.createdBy : null;
            int? modifiedBy = jsonData.modifiedBy != "" ? jsonData.modifiedBy : null;

            string firstName = jsonData.firstName;
            string lastName = jsonData.lastName;
            string email = jsonData.email;
            string encryptedPassword = jsonData.encryptedPassword;
            string mobileNo = jsonData.mobileNo;
            string address = jsonData.address;

            string designation = jsonData.designation;

            StaffBuilder builder = new StaffBuilder();
            builder.SetDesignation(designation);

            builder.SetFirstName(firstName);
            builder.SetLastName(lastName);
            builder.SetEmail(email);
            builder.SetAddress(address);
            builder.SetEncryptedPassword(encryptedPassword);
            builder.SetMobileNo(mobileNo);

            builder.SetId(id);
            builder.SetCreatedOn(createdOn);
            builder.SetCreatedBy(createdBy);
            builder.SetModifiedOn(modifiedOn);
            builder.SetModifiedBy(modifiedBy);


            Staff staff = builder.Build();
            return staff;
        }

    }
}
