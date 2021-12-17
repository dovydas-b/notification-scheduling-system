using System;
using Microsoft.Extensions.DependencyInjection;
using NSS.Infrastructure.Commands.Contracts;

namespace NSS.Infrastructure.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommandExecutor<TRequest, TResponse> Get<TRequest, TResponse>()
        {
            return serviceProvider.GetService<ICommandExecutor<TRequest, TResponse>>();
        }
    }
}
