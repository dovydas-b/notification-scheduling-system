using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using notification_scheduling_system.DataContracts.Enums;

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


        [Column(TypeName = "nvarchar(24)")]
        public CompanyType Type { get; set; }


        [Column(TypeName = "nvarchar(24)")]
        public MarketType MarketType { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }
}