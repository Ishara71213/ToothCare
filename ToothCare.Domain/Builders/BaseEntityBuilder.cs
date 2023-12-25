using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Builders
{
    public class BaseEntityBuilder
    {
        protected int id;
        protected DateTime? createdOn = DateTime.Now;
        protected int? createdBy;
        protected DateTime? modifiedOn;
        protected int? modifiedBy;

        protected BaseEntityBuilder()
        {
        }

        protected BaseEntityBuilder(int id)
        {
            this.id = id;
        }


        protected BaseEntityBuilder(int id, DateTime? createdOn, int? createdBy)
        {
            this.id = id;
            this.createdOn = createdOn;
            this.createdBy = createdBy;
        }

        public virtual BaseEntity Build()
        {
            return new BaseEntity(id, createdOn, createdBy, modifiedBy, modifiedOn);
        }

        public BaseEntityBuilder SetId(int id)
        {
            this.id = id;
            return this;
        }

        public BaseEntityBuilder SetCreatedOn(DateTime? createdOn)
        {
            this.createdOn = createdOn;
            return this;
        }


        public BaseEntityBuilder SetCreatedBy(int? createdBy)
        {
            this.createdBy = createdBy;
            return this;
        }


        public BaseEntityBuilder SetModifiedOn(DateTime? modifiedOn)
        {
            this.modifiedOn = modifiedOn;
            return this;
        }

        public BaseEntityBuilder SetModifiedBy(int? modifiedBy)
        {
            this.modifiedBy = modifiedBy;
            return this;
        }
    }
}
