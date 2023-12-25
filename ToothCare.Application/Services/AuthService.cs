using ToothCare.Domain.DataStructures;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;

namespace ToothCare.Application.Services
{
    public class AuthService : IAuthService
    {
        private bool _isAuthenticated;
        private Staff? _authenticatedUser;

        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository) {
            _authRepository=authRepository;
        }

        public Staff? GetCurrentUser()
        {
            return _authenticatedUser;
        }

        public bool IsAuthenticated()
        {
            return _isAuthenticated;
        }

        public Task<Staff> SetCurrentUser(Staff staff)
        {
            throw new NotImplementedException();
        }

        public async Task<Staff> SignIn(string email, string password)
        {
            CustomLinkedList<Staff> staffUsers = await _authRepository.GetAllAsync();
            Staff? user = staffUsers.Where((e) => e.GetEmail() == email && e.GetEncryptedPassword() == password).GetFirst();
            if (user == null)
            {
                throw new Exception("No user Found for Given Email password combination");
            }
            _isAuthenticated = true;
            _authenticatedUser = user;
            return _authenticatedUser!;
        }

        public void SignOut()
        {
            _isAuthenticated = false;
        }
    }
}
