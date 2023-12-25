using ToothCare.Domain.Entities;

namespace ToothCare.Presentation.Models
{
    public class PatientViewModel : BaseViewModel<Patient>
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string EncryptedPassword { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string Address { get; set; }  = string.Empty;

        public string Illness { get; set; } = string.Empty;

        public string Alergies { get; set; } = string.Empty;

        public string EmergencyContact { get; set; } = string.Empty;
    }
}
