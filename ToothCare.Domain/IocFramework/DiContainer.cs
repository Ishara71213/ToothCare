using System.Reflection;
using ToothCare.Domain.Enums;

namespace ToothCare.Domain.IocFramework
{
    public class DiContainer : IDiContainer
    {
        private List<ServiceDescriptor> _serviceDescriptors;
        public DiContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }
        public object GetService(Type serviceType)
        {
            var descriptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == serviceType);

            if (descriptor == null)
            {
                    throw new Exception($"Service of type {serviceType.Name} not registerd");
            }

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }
            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception($"Cannot Instantiate abstract classes or interfaces");
            }

            var contructorInfo = actualType.GetConstructors().First();
            var parameters=contructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType,parameters)!;

            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                descriptor.Implementation = implementation;
            }
            return implementation;
        }
        public T GetService<T>()
        {
           return (T)GetService(typeof(T));
        }

    }
}