using Newtonsoft.Json;
using ToothCare.Domain.Builders;
using ToothCare.Domain.Interfaces.Common;

namespace ToothCare.Domain.Entities
{
    public class Doctor : User, IJsonConvertible<Doctor>
    {
        internal string registrationNumber = string.Empty;

        public Doctor() { }

        //Constructors internal because object creation is centerlized into the Builders
        // these constructors will not be used in other Assemblies
        internal Doctor(string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string registrationNumber)
            : base(firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.registrationNumber = registrationNumber;
        }

        internal Doctor(int id, string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string registrationNumber)
            : base(id, firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.registrationNumber = registrationNumber;
        }

        internal Doctor(int id, DateTime? createdOn, int? createdBy, DateTime? modifiedOn, int? modifiedBy, string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string registrationNumber)
            : base(id, createdOn, createdBy, modifiedOn, modifiedBy, firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.registrationNumber = registrationNumber;
        }

        public string GetRegistrationNumber()
        {
            return this.registrationNumber;
        }

        public void SetregistrationNumber(string registrationNumber)
        {
            this.registrationNumber = registrationNumber;
        }

        //overides the to string and generate string as json format
        public override string ToString()
        {
            string resultBase = $"\"id\":\"{this.id}\", \"createdOn\":\"{this.createdOn}\", \"createdBy\":\"{this.createdBy}\", \"modifiedOn\":\"{this.modifiedOn}\", \"modifiedBy\":\"{this.modifiedBy}\", ";
            string resultUser = $"\"firstName\":\"{this.firstName}\", \"lastName\":\"{this.lastName}\", \"email\":\"{this.email}\", \"encryptedPassword\":\"{this.GetEncryptedPassword()}\", \"mobileNo\":\"{this.mobileNo}\", \"address\":\"{this.address}\", ";
            string resultDoctor = $"\"registrationNumber\":\"{this.registrationNumber}\"";

            string result = "{" + resultBase + resultUser + resultDoctor + "}";
            return result;
        }

        //From json method will create Instance from the corresponding json string
        public override Doctor FromJson(string json)
        {
            if (!json.Contains("id"))
            {
                return new Doctor();
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

            string registrationNumber = jsonData.registrationNumber;

            DoctorBuilder builder = new DoctorBuilder();
            builder.SetregistrationNumber(registrationNumber);

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


            Doctor doctor = builder.Build();
            return doctor;
        }
    }
}
