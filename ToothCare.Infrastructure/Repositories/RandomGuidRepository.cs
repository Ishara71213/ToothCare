using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToothCare.Domain.Interfaces.IRepositories;

namespace ToothCare.Infrastructure.Repositories
{
    public class RandomGuidRepository : IRandomGuidRepository
    {
        public Guid RandomGuid {  get;  } = Guid.NewGuid();
    }
}
