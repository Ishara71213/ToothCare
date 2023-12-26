using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;

namespace ToothCare.Presentation.Models
{
    public class AppointmentViewModel : BaseViewModel<Appointment>
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public int DoctorId { get; set; }

        public int TreatmentTypeId { get; set; }

        public int PaymentId { get; set; }

        //Time is calculated from minutes
        public int Duration { get; set; }

        //If the Appointment confirmed on appointment day
        public bool IsConfirmed { get; set; }

        public bool IsComplete { get; set; }
        public bool IsAdvancePaid { get; set; }

        public DateTime DateTime { get; set; }

        //filters to filter the appointment
        public string? FilterName { get; set; }
        public int FilterID { get; set; }
        public DateTime? FilterFromDate { get; set; }
        public DateTime? FilterToDate { get; set; }
        public int FilterDoctorId { get; set; }

        public PatientViewModel? Patient { get; set; } = new PatientViewModel();
        public PaymentViewModel? Payment { get; set; } = new PaymentViewModel();
        public CustomLinkedList<Doctor>? Doctors { get; set; }
        public CustomLinkedList<Treatment>? Treatments { get; set; }

    }
}
