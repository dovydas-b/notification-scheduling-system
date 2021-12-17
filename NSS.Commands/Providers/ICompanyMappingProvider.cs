using notification_scheduling_system.DataContracts.Dtos;
using notification_scheduling_system.DataContracts.Enums;

namespace NSS.Commands.Providers
{
    public interface ICompanyMappingProvider
    {
        CompanyScheduleDaysMappingDto GetCompanyScheduleDaysMappingByMarket(MarketType marketType);
    }
}