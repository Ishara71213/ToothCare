using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;

namespace ToothCare.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository) 
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment?> AddAsync(Payment entity)
        {
            return await _paymentRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _paymentRepository.DeleteAsync(id);
        }

        public async Task<CustomLinkedList<Payment>> GetAllAsync()
        {
           return await _paymentRepository.GetAllAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
           return await _paymentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Payment entity)
        {
            await _paymentRepository.UpdateAsync(entity);
        }
    }
}
