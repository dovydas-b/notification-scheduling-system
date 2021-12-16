using System;
using System.ComponentModel.DataAnnotations;

namespace notification_scheduling_system.DataContracts.Domain
{
    public class NotificationSchedule : BaseEntity
    {
        [Required]
        public DateTime SendingDate { get; set; }
    }
}