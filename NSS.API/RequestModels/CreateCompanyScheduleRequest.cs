using System.ComponentModel.DataAnnotations;
using notification_scheduling_system.DataContracts.Enums;

namespace notification_scheduling_system.RequestModels
{
    public class CreateCompanyScheduleRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public CompanyType Type { get; set; }

        [Required]
        public MarketType MarketType { get; set; }
    }
}