using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Interfaces.IServices
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<CustomLinkedList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
