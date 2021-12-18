using System;

namespace notification_scheduling_system.DataContracts.Domain
{
    public class Notification
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }

        public DateTime SendingDate { get; set; }
    }
}