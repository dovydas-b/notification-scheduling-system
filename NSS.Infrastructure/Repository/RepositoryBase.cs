using System;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace NSS.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                await dbContext.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken,
            bool saveChanges = true)
        {
            dbContext.Set<TEntity>().Add(entity);

            if (saveChanges)
            {
                return await this.SaveChangesAsync(cancellationToken) ? entity : null;
            }

            return entity;
        }
    }
}