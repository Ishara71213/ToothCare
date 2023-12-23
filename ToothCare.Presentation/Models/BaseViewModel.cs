namespace ToothCare.Presentation.Models
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public bool IsExist { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
