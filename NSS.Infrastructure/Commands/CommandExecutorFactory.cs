using System;
using Microsoft.Extensions.DependencyInjection;
using NSS.Infrastructure.Commands.Contracts;

namespace NSS.Infrastructure.Commands
{
    public class CommandExecutorFactory : ICommandExecutorFactory
    {
        private readonly IServiceProvider serviceProvider;

        public CommandExecutorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommandExecutor<TRequest, TResponse> Get<TRequest, TResponse>()
        {
            return serviceProvider.GetService<ICommandExecutor<TRequest, TResponse>>();
        }
    }
}
