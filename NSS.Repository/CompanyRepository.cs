using notification_scheduling_system.DataContracts.Domain;
using NSS.Infrastructure.Repository;
using NSS.Repository.Context;
using NSS.Repository.Contracts;

namespace NSS.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(NotificationSchedulingDbContext dbContext) : base(dbContext)
        {
        }
    }
}