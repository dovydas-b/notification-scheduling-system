using System;
using System.Collections.Generic;

namespace NSS.Infrastructure.Commands.DataContracts
{
    public class ErrorResult
    {
        public ErrorType ErrorType { get; }

        public IEnumerable<Error> Errors { get; }

        public ErrorResult(ErrorType errorType, IEnumerable<Error> errors)
        {
            ErrorType = errorType;
            Errors = errors;
        }

        public static ErrorResult FromException(Exception exception, bool includeStackTrace = false)
        {
            var errorList = new[]
            {
                new Error(exception.Message, includeStackTrace ? exception.StackTrace : null)
            };

            return new ErrorResult(ErrorType.Unhandled, errorList);
        }
    }
}
