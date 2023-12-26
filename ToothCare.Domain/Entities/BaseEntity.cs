using Newtonsoft.Json;
using ToothCare.Domain.Interfaces.Common;

namespace ToothCare.Domain.Entities
{
    //Every class will Extends from this base class 
    // IJsonConvertible responsible to enforce the implement Tostring and From json methods
    public class BaseEntity : IJsonConvertible<BaseEntity>
    {
        public int id;
        protected DateTime? createdOn= DateTime.Now;
        protected int? createdBy;
        protected DateTime? modifiedOn;
        protected int? modifiedBy;

        public BaseEntity()
        {
        }

        //Constructors internal because object creation is centerlized into the Builders
        // these constructors will not be used other Assemblies
        internal BaseEntity(int id)
        {
            this.id = id;
        }

        internal BaseEntity(int id, DateTime? createdOn,  int? createdBy, int? modifiedBy, DateTime? modifiedOn ) { 
            this.id = id;
            this.createdOn = createdOn;
            this.createdBy = createdBy;
            this.modifiedOn = modifiedOn;
            this.modifiedBy = modifiedBy;
        }
        public int GetId()
        {
            return this.id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }


        public DateTime? GetCreatedOn()
        {
            return this.createdOn;
        }

        public void SetCreatedOn(DateTime createdOn)
        {
            this.createdOn = createdOn;
        }

        public int? GetCreatedBy()
        {
            return this.createdBy;
        }

        public void SetCreatedBy(int? createdBy)
        {
            this.createdBy = createdBy;
        }

        public DateTime? GetModifiedOn()
        {
            return this.modifiedOn;
        }

        public void SetModifiedOn(DateTime? modifiedOn)
        {
            this.modifiedOn = modifiedOn;
        }

        public int? GetModifiedBy()
        {
            return this.modifiedBy;
        }

        public void SetModifiedBy(int? modifiedBy)
        {
            this.modifiedBy = modifiedBy;
        }

        //overides the to string and generate string as json format
        public override string ToString()
        {
            string resultBase = $"\"id\":\"{this.id}\", \"createdOn\":\"{this.createdOn}\", \"createdBy\":\"{this.createdBy}\", \"modifiedOn\":\"{this.modifiedOn}\", \"modifiedBy\":\"{this.modifiedBy}\"";

            string result = "{" + resultBase + "}";
            return result;
        }

        //From json method will create Instance from the corresponding json string
        // This Method is Virtual because every child classes will Overide this method 
        public virtual BaseEntity FromJson(string data)
        {

            dynamic jsonData = JsonConvert.DeserializeObject(data)!;
            BaseEntity staff = new BaseEntity(jsonData.id, jsonData.createdOn, jsonData.createdBy, jsonData.modifiedOn, jsonData.modifiedBy);
            return staff;
        }
    }


}
