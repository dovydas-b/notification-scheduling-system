using System;
using System.Threading;
using System.Threading.Tasks;
using notification_scheduling_system.DataContracts.Domain;
using NSS.Infrastructure.Repository;

namespace NSS.Repository.Contracts
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetCompanyById(Guid id, CancellationToken cancellationToken);
    }
}