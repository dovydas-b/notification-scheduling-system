using System;

namespace notification_scheduling_system.DataContracts.Domain
{
    public class Notification
    {
        public int Id { get; set; }

        public DateTime SendingDate { get; set; }
    }
}