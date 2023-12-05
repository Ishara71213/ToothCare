using System.Security.Cryptography.X509Certificates;

namespace ToothCare.Presentation.Extentions
{
    public class RandomGuidGenerator
    {
        public Guid RandomGuid {  get; set; } = Guid.NewGuid(); 
    }
}
