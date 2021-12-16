using System.Threading;
using System.Threading.Tasks;
using NSS.Infrastructure.Commands.DataContracts;

namespace NSS.Infrastructure.Commands.Contracts
{
    public interface ICommand<in TRequest, TResponse>
    {
        Task<CommandResponse<TResponse>> ExecuteAsync(TRequest request, CancellationToken cancellationToken);
    }
}