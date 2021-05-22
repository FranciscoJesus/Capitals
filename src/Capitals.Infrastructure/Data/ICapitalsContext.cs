using Capitals.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Capitals.Infrastructure.Data
{
    public interface ICapitalsContext
    {
        #region [Entities]
        public DbSet<Country> Countries { get; set; }
        public DbSet<Capital> Capitals { get; set; }
        #endregion

        DatabaseFacade Database { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken());

        EntityEntry Entry(object entity);

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        EntityEntry Attach(object entity);
        void Dispose();
    }
}
