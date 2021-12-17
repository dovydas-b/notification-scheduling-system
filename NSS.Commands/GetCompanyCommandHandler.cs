using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using notification_scheduling_system.DataContracts.Command.Request;
using notification_scheduling_system.DataContracts.Command.Response;
using NSS.Infrastructure.Commands.Contracts;
using NSS.Infrastructure.Commands.DataContracts;
using NSS.Repository.Contracts;

namespace NSS.Commands
{
    public class GetCompanyCommandHandler : ICommand<GetCompanyCommandHandlerRequest, GetCompanyCommandHandlerResponse>
    {
        private readonly ICompanyRepository companyRepository;

        public GetCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<CommandResponse<GetCompanyCommandHandlerResponse>> ExecuteAsync(
            GetCompanyCommandHandlerRequest request, CancellationToken cancellationToken)
        {
            var entity = await companyRepository.GetCompanyById(request.Id, cancellationToken);

            if (entity == null)
            {
                return CommandResponse<GetCompanyCommandHandlerResponse>.CreateFailure(ErrorType.NotFound,
                    $"Entity with {request.Id} not found");
            }

            return CommandResponse<GetCompanyCommandHandlerResponse>.CreateSuccess(new GetCompanyCommandHandlerResponse
            {
                CompanyId = entity.Id,
                Notifications = entity.Notifications.Select(x => x.SendingDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture))
            });
        }
    }
}