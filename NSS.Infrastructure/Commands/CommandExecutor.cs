using System;
using System.Threading;
using System.Threading.Tasks;
using NSS.Infrastructure.Commands.Contracts;
using NSS.Infrastructure.Commands.DataContracts;

namespace NSS.Infrastructure.Commands
{
    public class CommandExecutor<TRequest, TResponse> : ICommandExecutor<TRequest, TResponse>
    {
        private readonly ICommand<TRequest, TResponse> commandAction;

        public CommandExecutor(ICommand<TRequest, TResponse> commandAction)
        {
            this.commandAction = commandAction;
        }

        public virtual async Task<CommandExecutorResult<TResponse>> ExecuteAsync(TRequest request, CancellationToken cancellationToken)
        {
            var result = default(CommandResponse<TResponse>);
            ErrorResult error = null;

            try
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    result = await commandAction.ExecuteAsync(request, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                error = ErrorResult.FromException(ex, true);
            }

            if (error != null || result?.Error != null)
            {
                return CommandExecutorResult<TResponse>
                    .CreateFailure(error ?? result.Error);
            }

            return CommandExecutorResult<TResponse>
                .CreateSuccess(result == default ? default : result.Payload);
        }
    }
}
