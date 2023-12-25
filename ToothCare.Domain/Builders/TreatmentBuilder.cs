using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Builders
{
    public class TreatmentBuilder : BaseEntityBuilder
    {
        private string name = string.Empty;
        private double price;
        private int averageMinutesPerSession;

        public TreatmentBuilder() { }
        public TreatmentBuilder(string name, double price, int averageMinutesPerSession)
            : base()
        {
            this.name = name;
            this.price = price;
            this.averageMinutesPerSession = averageMinutesPerSession;
        }

        public TreatmentBuilder(int id, string name, double price, int averageMinutesPerSession)
            : base(id)
        {
            this.name = name;
            this.price = price;
            this.averageMinutesPerSession = averageMinutesPerSession;
        }

        public override Treatment Build()
        {
            return new Treatment(id, createdOn, createdBy, modifiedOn, modifiedBy, name, price, averageMinutesPerSession);
        }

        public TreatmentBuilder SetName(string name)
        {
            this.name = name;
            return this;    
        }

        public TreatmentBuilder SetPrice(double price)
        {
            this.price = price;
            return this;
        }

        public TreatmentBuilder SetAverageMinutesPerSession(int averageMinutesPerSession)
        {
            this.averageMinutesPerSession = averageMinutesPerSession;
            return this;
        }
    }
}
