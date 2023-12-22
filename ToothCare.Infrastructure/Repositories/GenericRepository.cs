
using ToothCare.Domain.Constatnts;
using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Infrastructure.Data;

namespace ECCMS.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly string _dbTable ;

        public GenericRepository(DbContext dbContext, string dbTable )
        {
            _dbContext = dbContext;
            _dbTable = dbTable;
        }

        async Task IGenericRepository<T>.AddAsync(T entity)
        {
            bool result = await _dbContext.WriteToFile<T>(_dbTable, entity);
            if (result!)
            {
                throw new Exception("Failed to write to Data base");
            }
        }

        async Task<CustomLinkedList<T>> IGenericRepository<T>.GetAllAsync()
        {
            CustomLinkedList<T>? list = await _dbContext.GetAllFromFile<T>(_dbTable);
            if (list == null)
            {
                list = new CustomLinkedList<T>();
            }
            return list;
        }

        async Task<T?> IGenericRepository<T>.GetByIdAsync(int id)
        {
            T? result = await _dbContext.GetRcordById<T>(_dbTable,id);
            return result;
        }

        async Task IGenericRepository<T>.UpdateAsync(T entity)
        {
            //havue to implement the update method
            bool result = await _dbContext.WriteToFile<T>(_dbTable, entity);
            if (result!)
            {
                throw new Exception("Failed to write to Data base");
            }
        }

        async Task IGenericRepository<T>.DeleteAsync(int id)
        {
            bool result = await _dbContext.DeleteRcordById<T>(_dbTable, id);
            if(result)
            {
                throw new Exception("Failed to Delete from Data base");
            }
        }
    }
}
