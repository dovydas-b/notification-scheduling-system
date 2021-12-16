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
    public class ScheduleController : ApiController
    {
        private readonly ICommandExecutorFactory commandExecutorFactory;

        public ScheduleController(ICommandExecutorFactory commandExecutorFactory)
        {
            this.commandExecutorFactory = commandExecutorFactory;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetCompanyScheduleCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await commandExecutorFactory
                .Get<GetCompanyScheduleCommandRequest, GetCompanyScheduleCommandResponse>()
                .ExecuteAsync(new GetCompanyScheduleCommandRequest
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
        [ProducesResponseType(typeof(CreateCompanyScheduleCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateCompanyScheduleRequest request,
            CancellationToken cancellationToken)
        {
            var result = await commandExecutorFactory
                .Get<CreateCompanyScheduleCommandRequest, CreateCompanyScheduleCommandResponse>()
                .ExecuteAsync(new CreateCompanyScheduleCommandRequest
                {
                    MarketType = request.MarketType,
                    Name = request.Name,
                    Number = request.Number,
                    Type = request.Type
                }, cancellationToken);

            if (!result.Success)
            {
                return this.CommandErrorResponse(result.Error);
            }

            return Ok(result.Result);
        }
    }
}