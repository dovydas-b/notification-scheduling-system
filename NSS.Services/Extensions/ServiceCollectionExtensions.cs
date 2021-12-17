using Microsoft.Extensions.DependencyInjection;
using NSS.Services.Contract;

namespace NSS.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IDateTimeProvider, DateTimeProvider>()
                .AddScoped<INotificationService, NotificationService>();

            return services;
        }
    }
}