using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using notification_scheduling_system.DataContracts.Domain;
using NSS.Infrastructure.Repository;
using NSS.Repository.Context;
using NSS.Repository.Contracts;

namespace NSS.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        private readonly NotificationSchedulingDbContext dbContext;

        public CompanyRepository(NotificationSchedulingDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Company> GetCompanyById(Guid id, CancellationToken cancellationToken)
        {
            return this.dbContext.Companies
                .Include(comp => comp.Notifications)
                .FirstOrDefaultAsync(comp => comp.Id == id, cancellationToken);
        }
    }
}