using Newtonsoft.Json;
using ToothCare.Domain.Builders;
using ToothCare.Domain.Interfaces.Common;

namespace ToothCare.Domain.Entities
{
    public class Patient : User, IJsonConvertible<Patient>
    {

        private string illness = string.Empty;

        private string alergies = string.Empty;

        private string emergencyContact = string.Empty;

        public Patient() { }

        //Constructors internal because object creation is centerlized into the Builders
        //these constructors will not be used in other Assemblies
        internal Patient(string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address)
            : base(firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
        }

        internal Patient(int id, string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string illness, string alergies, string emergencyContact)
            : base(id, firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.illness = illness;
            this.alergies = alergies;
            this.emergencyContact = emergencyContact;
        }

        internal Patient(int id, DateTime? createdOn, int? createdBy, DateTime? modifiedOn, int? modifiedBy, string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string illness, string alergies, string emergencyContact)
            : base(id, createdOn, createdBy, modifiedOn, modifiedBy, firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.illness = illness;
            this.alergies = alergies;
            this.emergencyContact = emergencyContact;
        }

        public string GetIllness()
        {
            return this.illness;
        }

        public void SetIllness(string illness)
        {
            this.illness = illness;
        }

        public string GetAlergies()
        {
            return this.alergies;
        }

        public void SetAlergies(string alergies)
        {
            this.alergies = alergies;
        }

        public string GetemergencyContact()
        {
            return this.emergencyContact;
        }

        public void SetEmergencyContact(string emergencyContact)
        {
            this.emergencyContact = emergencyContact;
        }

        //overides the to string and generate string as json format
        public override string ToString()
        {
            string resultBase = $"\"id\":\"{this.id}\", \"createdOn\":\"{this.createdOn}\", \"createdBy\":\"{this.createdBy}\", \"modifiedOn\":\"{this.modifiedOn}\", \"modifiedBy\":\"{this.modifiedBy}\", ";
            string resultUser = $"\"firstName\":\"{this.firstName}\", \"lastName\":\"{this.lastName}\", \"email\":\"{this.email}\", \"encryptedPassword\":\"{this.GetEncryptedPassword()}\", \"mobileNo\":\"{this.mobileNo}\", \"address\":\"{this.address}\", ";
            string resultPatient = $"\"illness\":\"{this.illness}\", \"alergies\":\"{this.alergies}\", \"emergencyContact\":\"{this.emergencyContact}\"";

            string result = "{" + resultBase + resultUser + resultPatient + "}";
            return result;
        }

        //From json method will create Instance from the corresponding json string
        public override Patient FromJson(string json)
        {
            if (!json.Contains("id"))
            {
                return new Patient();
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

            string illness = jsonData.illness;
            string alergies = jsonData.alergies;
            string emergencyContact = jsonData.emergencyContact;

            PatientBuilder builder = new PatientBuilder();
            builder.SetIllness(illness);
            builder.SetAlergies(alergies);
            builder.SetEmergencyContact(emergencyContact);

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


            Patient patient = builder.Build();
            return patient;
        }
    }
}
