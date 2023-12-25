using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Interfaces.IServices
{
    public interface IPatientService : IGenericService<Patient>
    {
        public Task<Patient?> GetByEmailAsync(string email);
    }
}
