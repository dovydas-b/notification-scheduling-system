using System.Threading;
using System.Threading.Tasks;

namespace NSS.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> InsertAsync(T entity, CancellationToken cancellationToken, bool saveChanges = true);
        
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    }
}