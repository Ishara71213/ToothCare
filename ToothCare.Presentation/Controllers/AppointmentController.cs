using Microsoft.AspNetCore.Mvc;
using ToothCare.Domain.Builders;
using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Presentation.Models;

namespace ToothCare.Presentation.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        private readonly ITreatmentService _treatmentService;

        public AppointmentController(IAuthService authService, IAppointmentService appointmentService, IDoctorService doctorService, ITreatmentService treatmentService )
        {
            _authService = authService;
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _treatmentService = treatmentService;
        }
        public async Task<IActionResult> Index()
        {
            AppointmentViewModel model = new AppointmentViewModel();
            var user = _authService.GetCurrentUser();
            if (user != null)
            {
                model.User = user;
            }
            model.AllList = await _appointmentService.GetAllAsync();
            model.Doctors = await _doctorService.GetAllAsync();
            model.Treatments = await _treatmentService.GetAllAsync();
            return View("Index", model);
        }

        public async Task<IActionResult> FilteredView(AppointmentViewModel model)
        {
            var user = _authService.GetCurrentUser();
            if (user != null)
            {
                model.User = user;
            }
            CustomLinkedList<Appointment> list= await _appointmentService.GetAllAsync();
            model.AllList = list;
            model.Doctors = await _doctorService.GetAllAsync();
            model.Treatments = await _treatmentService.GetAllAsync();

            //Filter by patient Name
            if(model.FilterName != default)
            {
                CustomLinkedList<Appointment> tempList = new();
                foreach (Appointment item in list)
                {
                    if (item.GetPatientName().ToLower().Contains(model.FilterName.ToLower()))
                    {
                        tempList.Add(item);
                    }
                }
                list = tempList;
                model.AllList = list;
            }

            //Filter by Appointment Id
            if (model.FilterID != default)
            {
                CustomLinkedList<Appointment> tempList = new();
                foreach (Appointment item in list)
                {
                    if (item.GetId() == model.FilterID)
                    {
                        tempList.Add(item);
                    }
                }
                list = tempList;
                model.AllList = list;
            }

            //Filter by Doctor
            if (model.FilterDoctorId != default)
            {
                CustomLinkedList<Appointment> tempList = new();
                foreach (Appointment item in list)
                {
                    if (item.GetDoctorId() == model.FilterDoctorId)
                    {
                        tempList.Add(item);
                    }
                }
                list = tempList;
                model.AllList = list;
            }

            //filter by from date
            if (model.FilterFromDate != default)
            {
                CustomLinkedList<Appointment> tempList = new();
                foreach (Appointment item in list)
                {
                    if (item.GetDateTime() > model.FilterFromDate)
                    {
                        tempList.Add(item);
                    }
                }
                list = tempList;
                model.AllList = list;
            }

            //filter by To date
            if (model.FilterToDate != default)
            {
                CustomLinkedList<Appointment> tempList = new();
                foreach (Appointment item in list)
                {
                    if (item.GetDateTime() < model.FilterToDate)
                    {
                        tempList.Add(item);
                    }
                }
                list = tempList;
                model.AllList = list;
            }
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(AppointmentViewModel model)
        {
            try
            {
                AppointmentBuilder builder = new AppointmentBuilder();
      
                builder.SetPatientId(model.PatientId);
                builder.SetPatientName(model.PatientName);
                builder.SetDoctorId(model.DoctorId);
                builder.SetTreatmentTypeId(model.TreatmentTypeId);
                builder.SetPaymentId(model.PaymentId);
                builder.SetDuration(model.Duration);
                builder.SetIsConfirmed(model.IsConfirmed);
                builder.SetIsComplete(model.IsComplete);
                builder.SetDateTime(model.DateTime);

                builder.SetId(model.Id);
                builder.SetCreatedBy(_authService.GetCurrentUser()!.GetId());
                builder.SetCreatedOn(DateTime.Now);

                Appointment entity = builder.Build();

                PatientBuilder patientBuilder = new PatientBuilder();
                patientBuilder.SetIllness(model!.Patient!.Illness);
                patientBuilder.SetAlergies(model!.Patient!.Alergies);
                patientBuilder.SetEmergencyContact(model!.Patient!.EmergencyContact);

                patientBuilder.SetFirstName(model!.Patient!.FirstName);
                patientBuilder.SetLastName(model!.Patient!.LastName);
                patientBuilder.SetEmail(model!.Patient!.Email);
                patientBuilder.SetMobileNo(model!.Patient!.MobileNo);
                patientBuilder.SetAddress(model!.Patient!.Address);

                patientBuilder.SetId(model.Id);
                patientBuilder.SetCreatedBy(_authService.GetCurrentUser()!.GetId());
                patientBuilder.SetCreatedOn(DateTime.Now);

                Patient patient = patientBuilder.Build();

                entity.patient = patient;
                await _appointmentService.AddAsync(entity);
                return RedirectToAction("Index", "Appointment", new { message = "Record Added Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Update(AppointmentViewModel model)
        {
            try
            {
                AppointmentBuilder builder = new AppointmentBuilder();

                builder.SetPatientId(model.PatientId);
                builder.SetPatientName(model.PatientName);
                builder.SetDoctorId(model.DoctorId);
                builder.SetTreatmentTypeId(model.TreatmentTypeId);
                builder.SetPaymentId(model.PaymentId);
                builder.SetDuration(model.Duration);
                builder.SetIsConfirmed(model.IsConfirmed);
                builder.SetIsComplete(model.IsComplete);
                builder.SetDateTime(model.DateTime);

                builder.SetId(model.Id);
                builder.SetModifiedBy(_authService.GetCurrentUser()!.GetId());
                builder.SetModifiedOn(DateTime.Now);

                Appointment entity = builder.Build();

                PatientBuilder patientBuilder = new PatientBuilder();
                patientBuilder.SetIllness(model!.Patient!.Illness);
                patientBuilder.SetAlergies(model!.Patient!.Alergies);
                patientBuilder.SetEmergencyContact(model!.Patient!.EmergencyContact);

                patientBuilder.SetFirstName(model!.Patient!.FirstName);
                patientBuilder.SetLastName(model!.Patient!.LastName);
                patientBuilder.SetEmail(model!.Patient!.Email);
                patientBuilder.SetMobileNo(model!.Patient!.MobileNo);
                patientBuilder.SetAddress(model!.Patient!.Address);

                patientBuilder.SetId(model.Id);
                patientBuilder.SetCreatedBy(_authService.GetCurrentUser()!.GetId());
                patientBuilder.SetCreatedOn(DateTime.Now);

                Patient patient = patientBuilder.Build();

                entity.patient = patient;

                await _appointmentService.UpdateAsync(entity);
                return RedirectToAction("Index", "Appointment", new { message = "Record Updated Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _appointmentService.DeleteAsync(id);
                return RedirectToAction("Index", "Appointment", new { message = "Record Deleted Succesfully" });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
    }
}
