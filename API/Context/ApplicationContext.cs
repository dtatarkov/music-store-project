using API.Entities;
using API.Settings;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.Context
{
    public class ApplicationContext: DbContext, IApplicationContext
    {
        private readonly AppSettings appSettings;

        public DbSet<Album> Albums { get; set; } = null!;

        public ApplicationContext(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var psqlBuilder = new NpgsqlConnectionStringBuilder(appSettings.DB.ConnectionString)
            {
                Password = appSettings.DB.Password
            };

            optionsBuilder.UseNpgsql(psqlBuilder.ConnectionString);
        }
    }
}
