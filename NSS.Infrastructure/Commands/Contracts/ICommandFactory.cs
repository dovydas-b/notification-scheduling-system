namespace NSS.Infrastructure.Commands.Contracts
{
    public interface ICommandFactory
    {
        ICommandExecutor<TRequest, TResponse> Get<TRequest, TResponse>();
    }
}
