using ToothCare.Domain.Entities;

namespace ToothCare.Domain.Interfaces.IRepositories
{
    public interface IRegisterRepository
    {
        public Task<bool> ValidateUser(Staff user);

        public Task<Staff> RegisterUser(Staff user);
    }
}
