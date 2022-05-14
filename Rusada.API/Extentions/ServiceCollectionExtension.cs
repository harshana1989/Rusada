using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rusada.Business.Extensions;

namespace Rusada.API.Extentions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // register business services
            services.RegisterBusinessServices(configuration);
            return services;
        }
    }
}
