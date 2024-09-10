using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Discount.Grpc.Data
{
    public static class Extension
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var dbContext = scope.ServiceProvider.GetService<DiscountContext>()!;
            dbContext.Database.MigrateAsync();

            return app;
        }
    }
}
