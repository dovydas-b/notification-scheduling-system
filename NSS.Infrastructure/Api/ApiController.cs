using Microsoft.AspNetCore.Mvc;
using NSS.Infrastructure.Commands.DataContracts;

namespace NSS.Infrastructure.Api
{
    public class ApiController : ControllerBase
    {
        [NonAction]
        public ObjectResult CommandErrorResponse(ErrorResult errorResult)
        {
            return errorResult?.ErrorType switch
            {
                ErrorType.Unhandled => StatusCode(500, errorResult),
                ErrorType.ModelValidation => StatusCode(400, errorResult),
                ErrorType.NotFound => StatusCode(404, errorResult),
                _ => StatusCode(500, errorResult)
            };
        }
    }
}