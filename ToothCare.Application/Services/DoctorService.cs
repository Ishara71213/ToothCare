using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;

namespace ToothCare.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository) 
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor?> AddAsync(Doctor entity)
        {
            return await _doctorRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }

        public async Task<CustomLinkedList<Doctor>> GetAllAsync()
        {
           return await _doctorRepository.GetAllAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
           return await _doctorRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Doctor entity)
        {
            await _doctorRepository.UpdateAsync(entity);
        }
    }
}
