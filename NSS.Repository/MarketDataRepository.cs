using System.Collections.Generic;
using notification_scheduling_system.DataContracts.Dtos;
using notification_scheduling_system.DataContracts.Enums;
using NSS.Repository.Contracts;

namespace NSS.Repository
{
    public class MarketDataRepository : IMarketDataRepository
    {
        private readonly Dictionary<MarketType, MarketDataDto> marketTypeMarketDataMap =
            new Dictionary<MarketType, MarketDataDto>
            {
                {
                    MarketType.Denmark, new MarketDataDto
                    {
                        ApplicableCompanyTypes = new[] {CompanyType.Small, CompanyType.Medium, CompanyType.Large},
                        SendNotificationOnDays = new[] {1, 5, 10, 15, 20}
                    }
                },
                {
                    MarketType.Norway, new MarketDataDto
                    {
                        ApplicableCompanyTypes = new[] {CompanyType.Small, CompanyType.Medium, CompanyType.Large},
                        SendNotificationOnDays = new[] {1, 5, 10, 20}
                    }
                },
                {
                    MarketType.Sweden, new MarketDataDto
                    {
                        ApplicableCompanyTypes = new[] {CompanyType.Small, CompanyType.Medium},
                        SendNotificationOnDays = new[] {1, 7, 14, 28}
                    }
                },
                {
                    MarketType.Finland, new MarketDataDto
                    {
                        ApplicableCompanyTypes = new[] {CompanyType.Large},
                        SendNotificationOnDays = new[] {1, 5, 10, 15, 20}
                    }
                }
            };

        public MarketDataDto GetMarketDataByMarketType(MarketType marketType)
        {
            return marketTypeMarketDataMap.ContainsKey(marketType)
                ? marketTypeMarketDataMap[marketType]
                : new MarketDataDto();
        }
    }
}