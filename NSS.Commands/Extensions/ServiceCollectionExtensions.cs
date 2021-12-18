using Microsoft.Extensions.DependencyInjection;
using notification_scheduling_system.DataContracts.Command.Request;
using notification_scheduling_system.DataContracts.Command.Response;
using NSS.Infrastructure.Commands;
using NSS.Infrastructure.Commands.Contracts;

namespace NSS.Commands.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services
                .AddScoped<ICommandFactory, CommandFactory>()
                .AddScoped(typeof(ICommandExecutor<,>), typeof(CommandExecutor<,>));

            services.AddScoped<ICommand<CreateCompanyCommandHandlerRequest, CreateCompanyCommandHandlerResponse>,
                CreateCompanyCommandHandler>();

            services.AddScoped<ICommand<GetCompanyCommandHandlerRequest, GetCompanyCommandHandlerResponse>,
                GetCompanyCommandHandler>();

            return services;
        }
    }
}