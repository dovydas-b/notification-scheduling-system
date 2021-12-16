namespace NSS.Infrastructure.Commands.Contracts
{
    public interface ICommandExecutorFactory
    {
        ICommandExecutor<TRequest, TResponse> Get<TRequest, TResponse>();
    }
}
