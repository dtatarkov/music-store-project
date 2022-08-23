using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Context
{
    public interface IApplicationContext
    {
        DbSet<Album> Albums { get; set; }

        public EntityEntry Add(object entity);
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
