using ToothCare.Domain.IocFramework;
using ToothCare.Presentation.Middleware;

namespace ToothCare.Presentation.Extention
{
    public static class RouteGuardMiddlewareExtention
    {
        public static IApplicationBuilder UseRouteGuard(this IApplicationBuilder app, DiContainer container)
        {
            app.UseMiddleware<RouteGuardMiddleware>(container);
            return app;
        }
    }
}
