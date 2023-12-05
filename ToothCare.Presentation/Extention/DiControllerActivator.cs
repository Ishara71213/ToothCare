﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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
            // Optionally release resources held by the controller
            // For example, dispose of IDisposable controllers
            if (controller is IDisposable disposableController)
            {
                disposableController.Dispose();
            }
        }
    }
}