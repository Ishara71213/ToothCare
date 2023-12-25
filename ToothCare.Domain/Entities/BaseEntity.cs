using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ToothCare.Domain.Interfaces.Common;

namespace ToothCare.Domain.Entities
{

    public class BaseEntity : IJsonConvertible<BaseEntity>
    {
        protected int id;
        protected DateTime? createdOn= DateTime.Now;
        protected int? createdBy;
        protected DateTime? modifiedOn;
        protected int? modifiedBy;

        public BaseEntity()
        {
        }

        public BaseEntity(int id)
        {
            this.id = id;
        }


        public BaseEntity(int id, DateTime? createdOn,  int? createdBy, int? modifiedBy, DateTime? modifiedOn ) { 
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

        public override string ToString()
        {
            string resultBase = $"\"id\":\"{this.id}\", \"createdOn\":\"{this.createdOn}\", \"createdBy\":\"{this.createdBy}\", \"modifiedOn\":\"{this.modifiedOn}\", \"modifiedBy\":\"{this.modifiedBy}\"";

            string result = "{" + resultBase + "}";
            return result;
        }

        public virtual BaseEntity FromJson(string data)
        {

            dynamic jsonData = JsonConvert.DeserializeObject(data)!;
            BaseEntity staff = new BaseEntity(jsonData.id, jsonData.createdOn, jsonData.createdBy, jsonData.modifiedOn, jsonData.modifiedBy);
            return staff;
        }
    }


}
