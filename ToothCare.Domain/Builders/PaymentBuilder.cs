using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Builders
{
    public class PaymentBuilder : BaseEntityBuilder
    {
        private int appointmentId;
        private double advance;
        private double total;
        private bool isPaid;

        public PaymentBuilder() { }
        public PaymentBuilder(int appointmentId, double advance, double total, bool isPaid)
            : base()
        {
            this.appointmentId = appointmentId;
            this.advance = advance;
            this.total = total;
            this.isPaid = isPaid;
        }

        public PaymentBuilder(int id, int appointmentId, double advance, double total, bool isPaid)
            : base(id)
        {
            this.appointmentId = appointmentId;
            this.advance = advance;
            this.total = total;
            this.isPaid = isPaid;
        }

        public override Payment Build()
        {
            return new Payment(id, createdOn,  createdBy,  modifiedOn, modifiedBy, appointmentId, advance, total, isPaid);
        }

        public PaymentBuilder SetAppointmentId(int appointmentId)
        {
            this.appointmentId = appointmentId;
            return this;
        }

        public PaymentBuilder SetAdvance(double advance)
        {
            this.advance = advance;
            return this;
        }

        public PaymentBuilder SetTotal(double total)
        {
            this.total = total;
            return this;
        }

        public PaymentBuilder SetIsPaid(bool isPaid)
        {
            this.isPaid = isPaid;
            return this;
        }
    }
}
