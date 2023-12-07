using ToothCare.Domain.Constatnts;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ToothCare.Presentation.Middleware
{

    public class RouteGuardMiddleware
    {
        private readonly RequestDelegate next;

        public RouteGuardMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            string? currentyUser = context.Session.GetString(SessionKeys.CURRENT_USER_ID);
            var routeData = context.GetRouteData();

            if (!string.IsNullOrEmpty(currentyUser))
            {
                await next.Invoke(context);
            }

            if (routeData.Values.Count > 0 && routeData.Values.ContainsKey("controller"))
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
