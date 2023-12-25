using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Builders
{
    public class DoctorBuilder : UserBuilder
    {
        private string registrationNumber = string.Empty;

        public DoctorBuilder() { }
        public DoctorBuilder(string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string registrationNumber)
            : base(firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.registrationNumber = registrationNumber;
        }

        public DoctorBuilder(int id, string firstName, string lastName, string email, string encryptedPassword, string mobileNo, string address, string registrationNumber)
            : base(id, firstName, lastName, email, encryptedPassword, mobileNo, address)
        {
            this.registrationNumber = registrationNumber;
        }


        public override Doctor Build()
        {
            return new Doctor(id, createdOn, createdBy, modifiedOn, modifiedBy, firstName, lastName, email, encryptedPassword, mobileNo, address, registrationNumber);
        }

        public DoctorBuilder SetregistrationNumber(string registrationNumber)
        {
            this.registrationNumber = registrationNumber;
            return this;
        }
    }
}
