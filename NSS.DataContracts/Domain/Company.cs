using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using notification_scheduling_system.DataContracts.Enums;

namespace notification_scheduling_system.DataContracts.Domain
{
    public class Company : BaseEntity
    {
        public Company()
        {
            this.Notifications = new List<NotificationSchedule>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Number { get; set; }

        [Required]
        public CompanyType Type { get; set; }

        [Required]
        public MarketType MarketType { get; set; }

        public ICollection<NotificationSchedule> Notifications { get; set; }
    }
}