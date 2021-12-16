using Microsoft.Extensions.DependencyInjection;
using NSS.Repository.Contracts;

namespace NSS.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<ICompanyRepository, CompanyRepository>();

            return services;
        }
    }
}