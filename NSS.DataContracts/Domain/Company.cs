using notification_scheduling_system.DataContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace notification_scheduling_system.DataContracts.Domain
{
    public sealed class Company
    {
        public Company()
        {
            this.Notifications = new List<Notification>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        [MaxLength(10)]
        public string Number { get; set; }

        public CompanyType Type { get; set; }

        public MarketType MarketType { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }
}