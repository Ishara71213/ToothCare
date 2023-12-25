using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;

namespace ToothCare.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository) 
        {
            _patientRepository = patientRepository;
        }

        public async Task AddAsync(Patient entity)
        {
            await _patientRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }

        public async Task<CustomLinkedList<Patient>> GetAllAsync()
        {
           return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
           return await _patientRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Patient entity)
        {
            await _patientRepository.UpdateAsync(entity);
        }
    }
}
