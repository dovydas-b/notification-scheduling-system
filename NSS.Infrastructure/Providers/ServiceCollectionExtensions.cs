using Microsoft.Extensions.DependencyInjection;

namespace NSS.Infrastructure.Providers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services
                .AddScoped<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}