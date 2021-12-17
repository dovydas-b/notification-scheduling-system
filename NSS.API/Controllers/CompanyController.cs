using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using notification_scheduling_system.DataContracts.Command.Request;
using notification_scheduling_system.DataContracts.Command.Response;
using notification_scheduling_system.RequestModels;
using NSS.Infrastructure.Api;
using NSS.Infrastructure.Commands.Contracts;
using NSS.Infrastructure.Commands.DataContracts;

namespace notification_scheduling_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ApiController
    {
        private readonly ICommandFactory commandFactory;

        public CompanyController(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetCompanyCommandHandlerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await commandFactory
                .Get<GetCompanyCommandHandlerRequest, GetCompanyCommandHandlerResponse>()
                .ExecuteAsync(new GetCompanyCommandHandlerRequest
                {
                    Id = id
                }, cancellationToken);

            if (!result.Success)
            {
                return this.CommandErrorResponse(result.Error);
            }

            return Ok(result.Result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateCompanyCommandHandlerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateCompanyScheduleRequest request,
            CancellationToken cancellationToken)
        {
            var result = await commandFactory
                .Get<CreateCompanyCommandHandlerRequest, CreateCompanyCommandHandlerResponse>()
                .ExecuteAsync(new CreateCompanyCommandHandlerRequest
                {
                    MarketType = request.MarketType.GetValueOrDefault(),
                    Name = request.Name,
                    Number = request.Number,
                    Type = request.Type.GetValueOrDefault()
                }, cancellationToken);

            if (!result.Success)
            {
                return this.CommandErrorResponse(result.Error);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Result.Id }, result.Result);
        }
    }
}