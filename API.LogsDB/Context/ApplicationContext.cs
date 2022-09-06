using API.LogsDB.Entities;
using API.LogsDB.Settings;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace API.LogsDB.Context
{
    public class ApplicationContext: DbContext
    {
        private readonly AppSettings appSettings;

        public DbSet<LogEntry> Logs { get; set; } = null!;

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
