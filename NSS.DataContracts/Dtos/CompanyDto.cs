using System;
using System.Collections.Generic;

namespace notification_scheduling_system.DataContracts.Dtos
{
    public class CompanyDto
    {
        public Guid CompanyId { get; set; }

        public IEnumerable<string> Notifications { get; set; }
    }
}