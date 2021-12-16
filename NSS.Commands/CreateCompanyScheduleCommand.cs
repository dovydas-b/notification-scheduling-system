using System.Threading;
using System.Threading.Tasks;
using notification_scheduling_system.DataContracts.Command.Request;
using notification_scheduling_system.DataContracts.Command.Response;
using notification_scheduling_system.DataContracts.Domain;
using notification_scheduling_system.DataContracts.Enums;
using NSS.Infrastructure.Commands.Contracts;
using NSS.Infrastructure.Commands.DataContracts;
using NSS.Repository.Contracts;

namespace NSS.Commands
{
    public class
        CreateCompanyScheduleCommand : ICommand<CreateCompanyScheduleCommandRequest,
            CreateCompanyScheduleCommandResponse>
    {
        private readonly ICompanyRepository companyRepository;

        public CreateCompanyScheduleCommand(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<CommandResponse<CreateCompanyScheduleCommandResponse>> ExecuteAsync(
            CreateCompanyScheduleCommandRequest request, CancellationToken cancellationToken)
        {
            var company = new Company
            {
                MarketType = MarketType.Denmark,
                Name = "Denmark",
                Number = "1223456",
                Type = CompanyType.Large,
            };

            var newEntity = await this.companyRepository.InsertAsync(company, cancellationToken);

            return CommandResponse<CreateCompanyScheduleCommandResponse>.CreateSuccess(
                new CreateCompanyScheduleCommandResponse
                {
                    Id = newEntity.Id
                });
        }
    }
}