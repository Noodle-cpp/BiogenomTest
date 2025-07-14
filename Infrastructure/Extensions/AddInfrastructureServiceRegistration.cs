using Application.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class AddInfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BiogenomDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres")));

            services.AddScoped<INutritionsReportRepository, NutritionsReportRepository>();
            services.AddScoped<ISupplementVitaminRepository, SupplementVitaminRepository>();
            return services;
        }
    }
}
