using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToothCare.Domain.IocFramework
{
    public interface IDiCollection
    {
        void RegisterSingleton<TService>();
        void RegisterSingleton<TService, TImplementation>() where TImplementation : TService;
        void RegisterSingleton<TService>(TService implementation);
        void RegisterTransient<TService>();
        void RegisterTransient<TService, TImplementation>() where TImplementation : TService;
        DiContainer GenerateContainer();
    }
}
