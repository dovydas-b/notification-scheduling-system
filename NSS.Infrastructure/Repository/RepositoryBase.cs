using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NSS.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken, bool disableValidation = false)
        {
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken, bool saveChanges = true)
        {
            dbContext.Set<TEntity>().Add(entity);

            if (saveChanges)
            {
                await dbContext.SaveChangesAsync(cancellationToken);
            }

            return entity;
        }
    }
}