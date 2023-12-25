using ToothCare.Domain.Builders;
using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;

namespace ToothCare.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly ITreatmentService _treatmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IPaymentService _paymentService;

        public AppointmentService(IAppointmentRepository appointmentRepository, IPaymentService paymentService, ITreatmentService treatmentService, IPatientService patientService, IDoctorService doctorService) 
        {
            _appointmentRepository = appointmentRepository;
            _doctorService = doctorService;
            _patientService = patientService;
            _treatmentService = treatmentService;
            _paymentService = paymentService;
        }

        public async Task<Appointment?> AddAsync(Appointment entity)
        {
            Patient? patient = await _patientService.GetByEmailAsync(entity.patient!.GetEmail());
            if (patient == null)
            {
                patient = await _patientService.AddAsync(entity.patient!);
                
            }
            else
            {
                await _patientService.UpdateAsync(entity.patient!);
            }
            Treatment? treatment = await _treatmentService.GetByIdAsync(entity.GetTreatmentTypeId());
            entity.SetDuration(treatment!.GetAverageMinutesPerSession());
            entity.SetPatientId(patient!.GetId());

            PaymentBuilder paymentBuilder = new PaymentBuilder();
            paymentBuilder.SetAdvance(1000.00);
            paymentBuilder.SetTotal(treatment.GetPrice());
            paymentBuilder.SetIsPaid(false);
            Payment? payment= paymentBuilder.Build();

            payment=await _paymentService.AddAsync(payment);
            entity.SetPaymentId(payment!.GetId());
            entity.SetPatientName(entity!.patient!.GetFirstName());

            return await _appointmentRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
        }

        public async Task<CustomLinkedList<Appointment>> GetAllAsync()
        {
           CustomLinkedList<Appointment> list= await _appointmentRepository.GetAllAsync();
            foreach (Appointment item in list)
            {
                item.patient = await _patientService.GetByIdAsync(item.GetPatientId());
                item.doctor = await _doctorService.GetByIdAsync(item.GetDoctorId());
                item.treatment = await _treatmentService.GetByIdAsync(item.GetTreatmentTypeId());
            }
            return list;
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
           return await _appointmentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Appointment entity)
        {
            await _appointmentRepository.UpdateAsync(entity);
        }
    }
}
