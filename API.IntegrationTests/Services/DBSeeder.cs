using API.Context;
using API.Entities;
using API.IntegrationTests.Data.Seeds;

namespace API.IntegrationTests.Services
{
    public class DBSeeder: IDBSeeder
    {
        public void SeedDB(ApplicationContext context)
        {
            context.Albums.AddRange(AlbumSeeds.Albums);
            context.SaveChanges();
        }
    }
}
