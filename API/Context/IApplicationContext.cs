using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Context
{
    public interface IApplicationContext
    {
        DbSet<Album> Albums { get; set; }

        public EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
