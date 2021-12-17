using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using notification_scheduling_system.DataContracts.Enums;
using notification_scheduling_system.ValidationAttributes;

namespace notification_scheduling_system.RequestModels
{
    public class CreateCompanyScheduleRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "The field {0} maximum length is {1}")]
        [NumericValidation]
        public string Number { get; set; }

        [Required]
        [EnumDataType(typeof(CompanyType))]
        public CompanyType? Type { get; set; }

        [Required]
        [EnumDataType(typeof(MarketType))]
        public MarketType? MarketType { get; set; }
    }
}