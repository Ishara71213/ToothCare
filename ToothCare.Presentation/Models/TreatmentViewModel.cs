namespace ToothCare.Presentation.Models
{
    public class TreatmentViewModel : BaseViewModel
    {
        public string Name { get; set; } = null!;
        public string Price { get; set; } = null!;
        //Time is calculated from minutes
        public int AvarageMinutesPerSession { get; set; }
    }
}
