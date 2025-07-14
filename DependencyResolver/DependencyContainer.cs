using Application.Extensions;
using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyResolver
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services,
                                                              IConfiguration configuration)
        {
            services.AddInfrastructureServices(configuration);
            services.AddApplicationServices();

            return services;
        }
    }
}
