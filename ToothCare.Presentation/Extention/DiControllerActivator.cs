using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using ToothCare.Domain.IocFramework;

namespace ToothCare.Presentation.Extention
{
    public class DiControllerActivator : IControllerActivator 
    {
        private readonly IDiContainer _diContainer;

        public DiControllerActivator(IDiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public object Create(ControllerContext context)
        {
            var controllerType = context.ActionDescriptor.ControllerTypeInfo.AsType();
            return _diContainer.GetService(controllerType);
        }

        public void Release(ControllerContext context, object controller)
        {
            // Release resources held by the controller
            if (controller is IDisposable disposableController)
            {
                disposableController.Dispose();
            }
        }
    }
}
