
using Newtonsoft.Json;
using ToothCare.Domain.Interfaces.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToothCare.Domain.Entities
{
    public class Treatment : BaseEntity , IJsonConvertible<Treatment>
    {
        public string name=string.Empty;
        public double price ;
        public int averageMinutesPerSession;

        public Treatment() { }
        public Treatment(string name, double price, int averageMinutesPerSession)
            : base()
        {
            this.name = name;
            this.price = price;
            this.averageMinutesPerSession = averageMinutesPerSession;
        }

        public Treatment(int id, string name, double price, int averageMinutesPerSession)
            : base(id)
        {
            this.name = name;
            this.price = price;
            this.averageMinutesPerSession = averageMinutesPerSession;
        }

        public Treatment(int id, DateTime? createdOn, int? createdBy, DateTime? modifiedOn, int? modifiedBy, string name, double price, int averageMinutesPerSession)
            : base(id,createdOn, createdBy, modifiedBy,  modifiedOn)
        {
            this.name = name;
            this.price = price;
            this.averageMinutesPerSession = averageMinutesPerSession;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public double GetPrice()
        {
            return this.price;
        }

        public void SetPrice(double price)
        {
            this.price = price;
        }

        public int GetAverageMinutesPerSession()
        {
            return this.averageMinutesPerSession;
        }

        public void SetAverageMinutesPerSession(int averageMinutesPerSession)
        {
            this.averageMinutesPerSession = averageMinutesPerSession;
        }

        public override string ToString()
        {
            string resultBase = $"\"id\":\"{this.id}\", \"createdOn\":\"{this.createdOn}\", \"createdBy\":\"{this.createdBy}\", \"modifiedOn\":\"{this.modifiedOn}\", \"modifiedBy\":\"{this.modifiedBy}\", ";
            string resultUser = $"\"name\":\"{this.name}\", \"price\":\"{this.price}\", \"averageMinutesPerSession\":\"{this.averageMinutesPerSession}\"";
           

            string result = "{" + resultBase + resultUser + "}";
            return result;
        }

        public override Treatment FromJson(string json)
        {
            if (!json.Contains("id"))
            {
                return new Treatment();
            }
            
            dynamic jsonData = JsonConvert.DeserializeObject(json)!;
            int id = jsonData.id != "" ? jsonData.id : 0;
            DateTime? createdOn = jsonData.createdOn != "" ? jsonData.createdOn : null;
            DateTime? modifiedOn = jsonData.modifiedOn != "" ? jsonData.modifiedOn : null;
            int? createdBy = jsonData.createdBy != "" ? jsonData.createdBy : null;
            int? modifiedBy = jsonData.modifiedBy != "" ? jsonData.modifiedBy : null;
            string name = jsonData.name;
            double price = jsonData.price != "" ? jsonData.price : 0;
            int averageMinutesPerSession = jsonData.averageMinutesPerSession!="" ? jsonData.averageMinutesPerSession : 0;
            

            Treatment treatment = new Treatment(id, createdOn, createdBy, modifiedOn, modifiedBy, name, price, averageMinutesPerSession );
            return treatment;
        }
    }
}
