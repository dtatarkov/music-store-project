using API.Entities;
using API.Settings;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Context
{
    public class ApplicationContext: DbContext, IApplicationContext
    {
        public DbSet<Album> Albums { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
