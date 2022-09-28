using API.Context;
using Microsoft.Extensions.Logging;

namespace API.IntegrationTests.Services
{
    public class DBInitializer : IDBInitializer
    {
        private readonly ApplicationContext context;
        private readonly IDBSeeder seeder;
        private readonly ILogger<DBInitializer> logger;

        public DBInitializer(
            ApplicationContext context, 
            IDBSeeder seeder,
            ILogger<DBInitializer> logger)
        {
            this.context = context;
            this.seeder = seeder;
            this.logger = logger;
        }

        public async Task Initialize()
        {
            context.Database.EnsureCreated();

            try
            {
                await seeder.SeedDB(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
            }
        }
    }
}
