using ToothCare.Domain.Entities;

namespace ToothCare.Presentation.Models
{
    public class PaymentViewModel : BaseViewModel<Payment>
    {
        public int PatientId { get; set; }

        public int AppointmentId { get; set; }

        public double Advance { get; set; }

        public double Total { get; set; }

        public bool IsPaid { get; set; }
    }
}
