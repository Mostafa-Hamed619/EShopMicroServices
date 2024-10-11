using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrasturcutrServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            
            //Add services to the containers
            //services.AddDbContext<ApplicationDbContext>(opt => {
            //opt.UseSqlServer(connectionString);
            //});

            //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


            return services;
        }
    }
}
