using System;
using System.Collections.Generic;

namespace notification_scheduling_system.DataContracts.Command.Response
{
    public class GetCompanyCommandHandlerResponse
    {
        public Guid CompanyId { get; set; }

        public IEnumerable<string> Notifications { get; set; }
    }
}