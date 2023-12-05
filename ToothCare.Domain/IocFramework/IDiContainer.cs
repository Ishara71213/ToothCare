using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToothCare.Domain.IocFramework
{
    public interface IDiContainer
    {
        T GetService<T>();

        object GetService(Type serviceType);
    }
}
