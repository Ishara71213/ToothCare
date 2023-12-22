using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.Entities;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;

namespace ToothCare.Application.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;
        public RegisterService(IRegisterRepository registerRepository) 
        {
            _registerRepository = registerRepository;
        }
        public async Task<Staff> RegisterUser(Staff user)
        {
            bool isValidated= await _registerRepository.ValidateUser(user);
            if (!isValidated)
            {
               
            }

            return await _registerRepository.RegisterUser(user);
        }

        public async Task<bool> ValidateUser(Staff user)
        {
            return await _registerRepository.ValidateUser(user);
        }
    }
}
