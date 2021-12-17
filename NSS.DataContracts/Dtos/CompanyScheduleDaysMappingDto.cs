using System.Collections.Generic;
using notification_scheduling_system.DataContracts.Enums;

namespace notification_scheduling_system.DataContracts.Dtos
{
    public class CompanyScheduleDaysMappingDto
    {
        public CompanyScheduleDaysMappingDto()
        {
            this.SendOnDays = new int[] { };
            this.ApplicableCompanyTypes = new CompanyType[] { };
        }

        public int[] SendOnDays { get; set; }

        public IEnumerable<CompanyType> ApplicableCompanyTypes { get; set; }
    }
}