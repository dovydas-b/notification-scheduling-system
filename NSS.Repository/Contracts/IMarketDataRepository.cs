using notification_scheduling_system.DataContracts.Dtos;
using notification_scheduling_system.DataContracts.Enums;

namespace NSS.Repository.Contracts
{
    public interface IMarketDataRepository
    {
        MarketDataDto GetMarketDataByMarketType(MarketType marketType);
    }
}