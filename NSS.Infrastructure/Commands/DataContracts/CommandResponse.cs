using System.Collections.Generic;
using System.Linq;

namespace NSS.Infrastructure.Commands.DataContracts
{
    public class CommandResponse<TPayload>
    {
        public TPayload Payload { get; }

        public ErrorResult Error { get; }

        public CommandResponse(TPayload payload)
        {
            Payload = payload;
        }

        public CommandResponse(ErrorResult error)
        {
            Error = error;
        }

        public static CommandResponse<TPayload> CreateSuccess(TPayload payload)
        {
            return new CommandResponse<TPayload>(payload);
        }

        public static CommandResponse<TPayload> CreateFailure(ErrorType type, IEnumerable<Error> errors)
        {
            var errorResult = new ErrorResult(type, errors);

            return new CommandResponse<TPayload>(errorResult);
        }

        public static CommandResponse<TPayload> CreateFailure(ErrorType type, string errorMessage)
        {
            var errorResult = new ErrorResult(type, new[] { new Error(errorMessage) });

            return new CommandResponse<TPayload>(errorResult);
        }

        public static CommandResponse<TPayload> CreateFailure(ErrorType type, IEnumerable<string> errorMessages)
        {
            var errorResult = new ErrorResult(type, errorMessages.Select(x => new Error(x)).ToArray());

            return new CommandResponse<TPayload>(errorResult);
        }
    }
}
