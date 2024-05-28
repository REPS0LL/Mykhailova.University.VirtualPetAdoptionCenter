using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualPetAdoptionCenter.Models.Configuration;

namespace VirtualPetAdoptionCenter.Core
{
    public static class DIConfiguration
    {
        public static void RegisterCoreDependencies(this IServiceCollection services)
        {
          
        }

        public static void RegisterCoreConfiguration(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AppConfig>(configuration.GetSection("AppConfig"));
        }
    }
}
