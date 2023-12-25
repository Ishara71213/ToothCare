using Newtonsoft.Json;
using ToothCare.Domain.Builders;
using ToothCare.Domain.Interfaces.Common;

namespace ToothCare.Domain.Entities
{
    public class Appointment : BaseEntity, IJsonConvertible<Appointment>
    {
        private int patientId;

        private string patientName = string.Empty;

        private int doctorId ;

        private int treatmentTypeId ;

        private int paymentId;

        private int duration;

        private DateTime dateTime;

        public Appointment() { }

        //Constructors internal because object creation is centerlized into the Builders
        //these constructors will not be used in other Assemblies
        internal Appointment(int id, DateTime? createdOn, int? createdBy, DateTime? modifiedOn, int? modifiedBy, int patientId, string patientName, int doctorId, int treatmentTypeId, int paymentId, int duration, DateTime dateTime )
            : base(id, createdOn, createdBy, modifiedBy, modifiedOn)
        {
            this.patientId = patientId;
            this.patientName = patientName;
            this.doctorId = doctorId;
            this.treatmentTypeId = treatmentTypeId;
            this.paymentId = paymentId;
            this.duration = duration;
            this.dateTime = dateTime;
        }

        public int GetPatientId()
        {
            return this.patientId;
        }

        public void SetPatientId(int patientId)
        {
            this.patientId = patientId;
        }

        public string GetPatientName()
        {
            return this.patientName;
        }

        public void SetPatientName(string patientName)
        {
            this.patientName = patientName;
        }

        public int GetDoctorId()
        {
            return this.doctorId;
        }

        public void SetDoctorId(int doctorId)
        {
            this.doctorId = doctorId;
        }

        public int GetTreatmentTypeId()
        {
            return this.treatmentTypeId;
        }

        public void SetTreatmentTypeId(int treatmentTypeId)
        {
            this.treatmentTypeId = treatmentTypeId;
        }

        public int GetPaymentId()
        {
            return this.paymentId;
        }

        public void SetPaymentId(int paymentId)
        {
            this.paymentId = paymentId;
        }

        public int GetDuration()
        {
            return this.duration;
        }

        public void SetDuration(int duration)
        {
            this.duration = duration;
        }

        public DateTime GetDateTime()
        {
            return this.dateTime;
        }

        public void SetDateTime(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        //overides the to string and generate string as json format
        public override string ToString()
        {
            string resultBase = $"\"id\":\"{this.id}\", \"createdOn\":\"{this.createdOn}\", \"createdBy\":\"{this.createdBy}\", \"modifiedOn\":\"{this.modifiedOn}\", \"modifiedBy\":\"{this.modifiedBy}\", ";
            string resultAppointment = $"\"patientId\":\"{this.patientId}\", \"patientName\":\"{this.patientName}\", \"doctorId\":\"{this.doctorId}\", \"treatmentTypeId\":\"{this.treatmentTypeId}\", \"paymentId\":\"{this.paymentId}\", \"duration\":\"{this.duration}\", \"dateTime\":\"{this.dateTime}\"";
            
            string result = "{" + resultBase + resultAppointment + "}";
            return result;
        }

        //From json method will create Instance from the corresponding json string
        public override Appointment FromJson(string json)
        {
            if (!json.Contains("id"))
            {
                return new Appointment();
            }

            dynamic jsonData = JsonConvert.DeserializeObject(json)!;

            int id = jsonData.id != "" ? jsonData.id : 0;
            DateTime? createdOn = jsonData.createdOn != "" ? jsonData.createdOn : null;
            DateTime? modifiedOn = jsonData.modifiedOn != "" ? jsonData.modifiedOn : null;
            int? createdBy = jsonData.createdBy != "" ? jsonData.createdBy : null;
            int? modifiedBy = jsonData.modifiedBy != "" ? jsonData.modifiedBy : null;

            int patientId = jsonData.patientId;
            string patientName = jsonData.patientName;
            int doctorId = jsonData.doctorId;
            int treatmentTypeId = jsonData.treatmentTypeId;
            int paymentId = jsonData.paymentId;
            int duration = jsonData.duration;
            DateTime dateTime = jsonData.dateTime != "" ? jsonData.dateTime : null;

            AppointmentBuilder builder = new AppointmentBuilder();
            builder.SetPatientId(patientId);
            builder.SetPatientName(patientName);
            builder.SetDoctorId(doctorId);

            builder.SetTreatmentTypeId(treatmentTypeId);
            builder.SetPaymentId(paymentId);
            builder.SetDuration(duration);
            builder.SetDateTime(dateTime);

            builder.SetId(id);
            builder.SetCreatedOn(createdOn);
            builder.SetCreatedBy(createdBy);
            builder.SetModifiedOn(modifiedOn);
            builder.SetModifiedBy(modifiedBy);

            Appointment patient = builder.Build();
            return patient;
        }
    }
}
