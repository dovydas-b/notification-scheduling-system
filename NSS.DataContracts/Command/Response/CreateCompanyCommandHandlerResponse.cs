using System;

namespace notification_scheduling_system.DataContracts.Command.Response
{
    public class CreateCompanyCommandHandlerResponse
    {
        public CreateCompanyCommandHandlerResponse(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}