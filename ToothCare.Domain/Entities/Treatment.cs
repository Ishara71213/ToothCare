
namespace ToothCare.Domain.Entities
{
    public class Treatment : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string AvarageTime { get; set; } = null!;
    }
}
