using notification_scheduling_system.DataContracts.Enums;
using System.Collections.Generic;
using notification_scheduling_system.DataContracts.Dtos;

namespace NSS.Commands.Providers
{
    public class CompanyMappingProvider : ICompanyMappingProvider
    {
        private readonly Dictionary<MarketType, CompanyScheduleDaysMappingDto> marketTypeNotificationMap =
            new Dictionary<MarketType, CompanyScheduleDaysMappingDto>
            {
                {
                    MarketType.Denmark, new CompanyScheduleDaysMappingDto
                    {
                        ApplicableCompanyTypes = new[] {CompanyType.Small, CompanyType.Medium, CompanyType.Large},
                        SendOnDays = new[] {1, 5, 10, 15, 20}
                    }
                },
                {
                    MarketType.Norway, new CompanyScheduleDaysMappingDto
                    {
                        ApplicableCompanyTypes = new[] {CompanyType.Small, CompanyType.Medium, CompanyType.Large},
                        SendOnDays = new[] {1, 5, 10, 20}
                    }
                },
                {
                    MarketType.Sweden, new CompanyScheduleDaysMappingDto
                    {
                        ApplicableCompanyTypes = new[] {CompanyType.Small, CompanyType.Medium},
                        SendOnDays = new[] {1, 7, 14, 28}
                    }
                },
                {
                    MarketType.Finland, new CompanyScheduleDaysMappingDto
                    {
                        ApplicableCompanyTypes = new[] {CompanyType.Large},
                        SendOnDays = new[] {1, 5, 10, 15, 20}
                    }
                }
            };

        public CompanyScheduleDaysMappingDto GetCompanyScheduleDaysMappingByMarket(MarketType marketType)
        {
            return marketTypeNotificationMap.ContainsKey(marketType) 
                ? marketTypeNotificationMap[marketType] 
                : new CompanyScheduleDaysMappingDto();
        }
    }
}