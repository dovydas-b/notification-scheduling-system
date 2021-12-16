using System.Threading;
using System.Threading.Tasks;
using NSS.Infrastructure.Commands.DataContracts;

namespace NSS.Infrastructure.Commands.Contracts
{
    public interface ICommandExecutor<in TRequest, TResponse>
    {
        Task<CommandExecutorResult<TResponse>> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}
