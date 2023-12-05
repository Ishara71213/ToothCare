using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.Interfaces.IRepositories;
using ToothCare.Domain.Interfaces.IServices;

namespace ToothCare.Application.Services
{
    public class ServiceOne : IServiceOne
    {
        private readonly IRandomGuidRepository _randomGuidRepository; 
        public ServiceOne(IRandomGuidRepository randomGuidRepository)
        {
            _randomGuidRepository=randomGuidRepository;
        }
        public void printSomething()
        {
            Console.WriteLine(_randomGuidRepository.RandomGuid);
        }
    }
}
