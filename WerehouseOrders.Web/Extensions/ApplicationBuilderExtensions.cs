using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WerehouseOrders.Data;

namespace WerehouseOrders.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder CreateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<WerehouseOrdersDbContext>().Database.EnsureCreated();
            }

            return app;
        }
    }
}