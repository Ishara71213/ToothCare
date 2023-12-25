
using Newtonsoft.Json;
using ToothCare.Domain.Builders;
using ToothCare.Domain.Interfaces.Common;

namespace ToothCare.Domain.Entities
{
    //This class responsible to create Instance of Payment Type data
    // IJsonConvertible responsible to enforce the implement Tostring and From json methods
    public class Payment : BaseEntity , IJsonConvertible<Payment> 
    {
        private int appointmentId;
        public double advance;
        public double total;
        public bool isPaid;

        public Payment() { }

        //Constructors internal because object creation is centerlized into the Builders
        // these constructors will not be used in other Assemblies
        internal Payment(int appointmentId, double advance, double total, bool isPaid)
            : base()
        {
            this.appointmentId = appointmentId;
            this.advance = advance;
            this.total = total;
            this.isPaid = isPaid;
        }

        internal Payment(int id, int appointmentId, double advance, double total, bool isPaid)
            : base(id)
        {
            this.appointmentId = appointmentId;
            this.advance = advance;
            this.total = total;
            this.isPaid = isPaid;
        }

        internal Payment(int id, DateTime? createdOn, int? createdBy, DateTime? modifiedOn, int? modifiedBy, int appointmentId, double advance, double total, bool isPaid)
            : base(id,createdOn, createdBy, modifiedBy,  modifiedOn)
        {
            this.appointmentId = appointmentId;
            this.advance = advance;
            this.total = total;
            this.isPaid = isPaid;
        }

        public int GetAppointmentId()
        {
            return this.appointmentId;
        }

        public void SetAppointmentId(int appointmentId)
        {
            this.appointmentId = appointmentId;
        }

        public double GetAdvance()
        {
            return this.advance;
        }

        public void SetAdvance(double advance)
        {
            this.advance = advance;
        }

        public double GetTotal()
        {
            return this.total;
        }

        public void SetTotal(double total)
        {
            this.total = total;
        }

        public double GetIsPaid()
        {
            return this.total;
        }

        public void SetIsPaid(double total)
        {
            this.total = total;
        }

        //overides the to string and generate string as json format
        public override string ToString()
        {
            string resultBase = $"\"id\":\"{this.id}\", \"createdOn\":\"{this.createdOn}\", \"createdBy\":\"{this.createdBy}\", \"modifiedOn\":\"{this.modifiedOn}\", \"modifiedBy\":\"{this.modifiedBy}\", ";
            string resultAppointmnet = $"\"appointmentId\":\"{this.appointmentId}\", \"advance\":\"{this.advance}\", \"total\":\"{this.total}\", \"isPaid\":\"{this.isPaid}\"";
           
            string result = "{" + resultBase + resultAppointmnet + "}";
            return result;
        }

        //From json method will create Instance from the corresponding json string
        public override Payment FromJson(string json)
        {
            if (!json.Contains("id"))
            {
                return new Payment();
            }
            
            dynamic jsonData = JsonConvert.DeserializeObject(json)!;

            int id = jsonData.id != "" ? jsonData.id : 0;
            DateTime? createdOn = jsonData.createdOn != "" ? jsonData.createdOn : null;
            DateTime? modifiedOn = jsonData.modifiedOn != "" ? jsonData.modifiedOn : null;
            int? createdBy = jsonData.createdBy != "" ? jsonData.createdBy : null;
            int? modifiedBy = jsonData.modifiedBy != "" ? jsonData.modifiedBy : null;

            int appointmentId = jsonData.appointmentId != "" ? jsonData.appointmentId : 0;
            double advance = jsonData.advance != "" ? jsonData.advance : 0;
            double total = jsonData.total != "" ? jsonData.total : 0;
            bool isPaid = jsonData.isPaid != "" ? jsonData.isPaid : false;

            PaymentBuilder builder = new PaymentBuilder();
            
            builder.SetAppointmentId(appointmentId);
            builder.SetAdvance(advance);
            builder.SetTotal(total);
            builder.SetIsPaid(isPaid);

            builder.SetId(id);
            builder.SetCreatedOn(createdOn);
            builder.SetCreatedBy(createdBy);
            builder.SetModifiedOn(modifiedOn);
            builder.SetModifiedBy(modifiedBy);

            Payment treatment = builder.Build();
            return treatment;
        }
    }
}
