using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;

namespace ToothCare.Application.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentService(ITreatmentRepository treatmentRepository) 
        {
            _treatmentRepository = treatmentRepository;
        }

        public async Task<Treatment?> AddAsync(Treatment entity)
        {
            Treatment? result=await _treatmentRepository.AddAsync(entity);
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            await _treatmentRepository.DeleteAsync(id);
        }

        public async Task<CustomLinkedList<Treatment>> GetAllAsync()
        {
           return await _treatmentRepository.GetAllAsync();
        }

        public async Task<Treatment?> GetByIdAsync(int id)
        {
           return await _treatmentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Treatment entity)
        {
            await _treatmentRepository.UpdateAsync(entity);
        }
    }
}
