using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using notification_scheduling_system.DataContracts.Command.Request;
using notification_scheduling_system.DataContracts.Command.Response;
using notification_scheduling_system.DataContracts.Dtos;
using NSS.Infrastructure.Commands.Contracts;
using NSS.Infrastructure.Commands.DataContracts;
using NSS.Repository.Contracts;

namespace NSS.Commands
{
    public class GetCompanyScheduleCommand : ICommand<GetCompanyScheduleCommandRequest, GetCompanyScheduleCommandResponse>
    {
        private readonly ICompanyRepository companyRepository;

        public GetCompanyScheduleCommand(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<CommandResponse<GetCompanyScheduleCommandResponse>> ExecuteAsync(GetCompanyScheduleCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await companyRepository.GetByIdAsync(request.Id, cancellationToken);

            return CommandResponse<GetCompanyScheduleCommandResponse>.CreateSuccess(new GetCompanyScheduleCommandResponse
            {
                Company = new CompanyDto
                {
                    CompanyId = entity.Id,
                    Notifications = entity.Notifications.Select(x => x.SendingDate.ToShortDateString())
                }
            });
        }
    }
}