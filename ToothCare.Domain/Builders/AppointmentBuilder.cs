using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Builders
{
    public class AppointmentBuilder : BaseEntityBuilder
    {
        private int patientId;

        private string patientName = string.Empty;

        private int doctorId;

        private int treatmentTypeId;

        private int paymentId;

        private int duration;

        private DateTime dateTime;

        public AppointmentBuilder() { }
        public AppointmentBuilder(int id, DateTime? createdOn, int? createdBy,int patientId, string patientName, int treatmentTypeId)
            : base( id, createdOn, createdBy)
        {
            this.patientId = patientId;
            this.patientName = patientName;
            this.treatmentTypeId = treatmentTypeId;
        }

        public override Appointment Build()
        {
            return new Appointment( id, createdOn, createdBy, modifiedOn, modifiedBy, patientId, patientName, doctorId, treatmentTypeId, paymentId, duration, dateTime);
        }

        public AppointmentBuilder SetPatientId(int patientId)
        {
            this.patientId = patientId;
            return this;
        }


        public AppointmentBuilder SetPatientName(string patientName)
        {
            this.patientName = patientName;
            return this;
        }


        public AppointmentBuilder SetDoctorId(int doctorId)
        {
            this.doctorId = doctorId;
            return this;
        }

        public AppointmentBuilder SetTreatmentTypeId(int treatmentTypeId)
        {
            this.treatmentTypeId = treatmentTypeId;
            return this;
        }

        public AppointmentBuilder SetPaymentId(int paymentId)
        {
            this.paymentId = paymentId;
            return this;
        }


        public AppointmentBuilder SetDuration(int duration)
        {
            this.duration = duration;
            return this;
        }


        public AppointmentBuilder SetDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
            return this;
        }
    }
}
