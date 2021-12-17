using notification_scheduling_system.DataContracts.Enums;

namespace notification_scheduling_system.DataContracts.Command.Request
{
    public class CreateCompanyCommandHandlerRequest
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public CompanyType Type { get; set; }

        public MarketType MarketType { get; set; }
    }
}