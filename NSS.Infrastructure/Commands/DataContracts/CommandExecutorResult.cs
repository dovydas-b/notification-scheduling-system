namespace NSS.Infrastructure.Commands.DataContracts
{
    public class CommandExecutorResult<TResponse>
    {
        public bool Success { get; private set; }

        public TResponse Result { get; private set; }

        public ErrorResult Error { get; private set; }

        public static CommandExecutorResult<TResponse> CreateSuccess(TResponse response)
        {
            return new CommandExecutorResult<TResponse>
            {
                Success = true, 
                Result = response
            };
        }

        public static CommandExecutorResult<TResponse> CreateFailure(ErrorResult errorResult)
        {
            return new CommandExecutorResult<TResponse>
            {
                Success = false, 
                Error = errorResult
            };
        }

        public static CommandExecutorResult<TResponse> CreateFailure(ErrorResult errorResult, TResponse response)
        {
            return new CommandExecutorResult<TResponse>
            {
                Success = false,
                Result = response,
                Error = errorResult
            };
        }
    }
}
