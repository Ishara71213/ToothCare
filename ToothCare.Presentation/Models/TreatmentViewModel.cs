using ToothCare.Domain.Entities;

namespace ToothCare.Presentation.Models
{
    public class TreatmentViewModel : BaseViewModel<Treatment>
    {
        public string Name { get; set; } = null!;
        public double Price { get; set; }

        //Time is calculated from minutes
        public int AvarageMinutesPerSession { get; set; }
    }
}
