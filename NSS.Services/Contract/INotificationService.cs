using System;
using System.Collections.Generic;
using notification_scheduling_system.DataContracts.Domain;

namespace NSS.Services.Contract
{
    public interface INotificationService
    {
        IEnumerable<DateTime> GetNotificationDatesByMarketType(Company company, DateTime startDate);
    }
}