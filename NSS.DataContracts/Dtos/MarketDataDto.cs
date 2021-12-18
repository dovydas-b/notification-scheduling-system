using System.Collections.Generic;
using notification_scheduling_system.DataContracts.Enums;

namespace notification_scheduling_system.DataContracts.Dtos
{
    public class MarketDataDto
    {
        public MarketDataDto()
        {
            this.SendNotificationOnDays = new int[] { };
            this.ApplicableCompanyTypes = new CompanyType[] { };
        }

        public int[] SendNotificationOnDays { get; set; }

        public IEnumerable<CompanyType> ApplicableCompanyTypes { get; set; }
    }
}