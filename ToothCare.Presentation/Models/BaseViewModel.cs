using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;

namespace ToothCare.Presentation.Models
{
    public class BaseViewModel<T>
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public Staff? User { get; set; }  

        public CustomLinkedList<T>? AllList { get; set;}
    }
}
