using ToothCare.Presentation.Middleware;

namespace ToothCare.Presentation.Extention
{
    public static class RouteGuardMiddlewareExtention
    {
        public static IApplicationBuilder UseRouteGuard(this IApplicationBuilder app)
        {
            app.UseMiddleware<RouteGuardMiddleware>();
            return app;
        }
    }
}
