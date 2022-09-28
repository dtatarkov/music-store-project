using API.Entities;

namespace API.IntegrationTests.Data.Seeds
{
    public static class AlbumSeeds
    {
        public static IEnumerable<Album> Albums = new[]
        {
            new Album
            {
                AlbumId = 1,
                Title = "Album 1",
                Description = "Album 1 Description",
                CreatedDate = DateTimeOffset.Now,
                UpdatedDate = DateTimeOffset.Now
            },

            new Album
            {
                AlbumId = 2,
                Title = "Album 2",
                Description = "Album 2 Description",
                CreatedDate = DateTimeOffset.Now,
                UpdatedDate = DateTimeOffset.Now
            },

            new Album
            {
                AlbumId = 3,
                Title = "Album 3",
                Description = "Album 3 Description",
                CreatedDate = DateTimeOffset.Now,
                UpdatedDate = DateTimeOffset.Now
            }
        };
    }
}
