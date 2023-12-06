using ToothCare.Presentation.Middleware;

namespace ToothCare.Presentation.Extention
{
    public static class HandleEndpointRoutingMiddlewareExtention
    {
        public static IApplicationBuilder UseHandleEndpointRouting(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Register}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            return app;
        }
    }
}
