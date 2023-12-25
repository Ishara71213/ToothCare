using ToothCare.Domain.Entities;

namespace ToothCare.Presentation.Models
{
    public class DoctorViewModel : BaseViewModel<Doctor>
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string MobileNo { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string RegistrationNumber { get; set; } = string.Empty;
    }
}
