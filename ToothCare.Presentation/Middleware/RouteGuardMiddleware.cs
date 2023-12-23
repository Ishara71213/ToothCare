using System.Security.Policy;
using ToothCare.Application.Services;
using ToothCare.Domain.Interfaces.IServices;
using ToothCare.Domain.IocFramework;


namespace ToothCare.Presentation.Middleware
{

    public class RouteGuardMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IAuthService authService;

        public RouteGuardMiddleware(RequestDelegate next, DiContainer container)
        {
            this.next = next;
            this.authService = (IAuthService)container.GetService(typeof(IAuthService));
        }

        public async Task Invoke(HttpContext context)
        {

            bool isAuthenticated = authService.IsAuthenticated();
            //string? currentyUser = context.Session.GetString(SessionKeys.CURRENT_USER_ID);
            var routeData = context.GetRouteData();


            if (routeData.Values.Count > 0 && routeData.Values.ContainsKey("controller") && !isAuthenticated)
            {
                var controllerName = routeData.Values["controller"]?.ToString() ?? "";
                var actionName = routeData.Values["action"]?.ToString() ?? "";


                if (controllerName == "Register" && actionName == "Index")
                {
                    await next.Invoke(context);
                }
                if (controllerName == "SignIn")
                {
                    await next.Invoke(context);
                }
                else
                {
                    context.Response.Redirect("Auth/SignIn/Index");
                }
            }

            


            await next.Invoke(context);
        }
    }
}
