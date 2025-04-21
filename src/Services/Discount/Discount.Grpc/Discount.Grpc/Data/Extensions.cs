using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public static class Extensions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app) 
        {
            try
            {
                using var scope = app.ApplicationServices.CreateScope();
                using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();
                dbContext.Database.MigrateAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return app;
        }
    }
}
