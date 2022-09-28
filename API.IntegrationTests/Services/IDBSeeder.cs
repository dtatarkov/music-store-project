using API.Context;

namespace API.IntegrationTests.Services
{
    public interface IDBSeeder
    {
        void SeedDB(ApplicationContext context);
    }
}
