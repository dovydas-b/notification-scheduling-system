using notification_scheduling_system.DataContracts.Command.Request;
using notification_scheduling_system.DataContracts.Command.Response;
using notification_scheduling_system.DataContracts.Domain;
using NSS.Infrastructure.Commands.Contracts;
using NSS.Infrastructure.Commands.DataContracts;
using NSS.Infrastructure.Providers;
using NSS.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NSS.Commands
{
    public class
        CreateCompanyCommandHandler : ICommand<CreateCompanyCommandHandlerRequest,
            CreateCompanyCommandHandlerResponse>
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IMarketDataRepository marketDataRepository;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository,
            IDateTimeProvider dateTimeProvider,
            IMarketDataRepository marketDataRepository)
        {
            this.companyRepository = companyRepository;
            this.dateTimeProvider = dateTimeProvider;
            this.marketDataRepository = marketDataRepository;
        }

        public async Task<CommandResponse<CreateCompanyCommandHandlerResponse>> ExecuteAsync(
            CreateCompanyCommandHandlerRequest request, CancellationToken cancellationToken)
        {
            var marketData = this.marketDataRepository
                .GetMarketDataByMarketType(request.MarketType);

            var dateTimeNow = dateTimeProvider.UtcNow();

            var notifications = marketData.ApplicableCompanyTypes.Contains(request.Type)
                ? marketData
                    .SendNotificationOnDays
                    .Select(sentDay => new Notification
                    {
                        SendingDate = dateTimeNow.AddDays(sentDay)
                    }).ToList()
                : new List<Notification>();

            var company = new Company
            {
                MarketType = request.MarketType,
                Name = request.Name,
                Number = request.Number,
                Type = request.Type,
                Notifications = notifications
            };

            var newEntity = await this.companyRepository.InsertAsync(company, cancellationToken);

            if (newEntity == null)
            {
                return CommandResponse<CreateCompanyCommandHandlerResponse>
                    .CreateFailure(ErrorType.Unhandled, "Unable to create entity");
            }

            return CommandResponse<CreateCompanyCommandHandlerResponse>.CreateSuccess(
                new CreateCompanyCommandHandlerResponse(newEntity.Id));
        }
    
    }
}