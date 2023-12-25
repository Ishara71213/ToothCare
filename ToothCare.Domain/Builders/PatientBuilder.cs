using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Builders
{
    public class PatientBuilder : UserBuilder
    {
        private string illness = string.Empty;

        private string alergies = string.Empty;

        private string emergencyContact = string.Empty;

        public PatientBuilder() { }
        public PatientBuilder(string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address)
            : base(firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
        }

        public override Patient Build()
        {
            return new  Patient( id, createdOn, createdBy, modifiedOn,  modifiedBy, firstName, lastName, email, encryptedPassword, mobileNo, address, illness, alergies, emergencyContact);
        }

        public PatientBuilder SetIllness(string illness)
        {
            this.illness = illness;
            return this;
        }

        public PatientBuilder SetAlergies(string alergies)
        {
            this.alergies = alergies;
            return this;
        }

        public PatientBuilder SetEmergencyContact(string emergencyContact)
        {
            this.emergencyContact = emergencyContact;
            return this;
        }
    }
}
