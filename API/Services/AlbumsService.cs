using API.Context;
using API.Entities;

namespace API.Services
{
    public class AlbumsService: IAlbumsService
    {
        private readonly IApplicationContext dbContext;

        public AlbumsService(IApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Album> GetAlbums()
        {
            return dbContext.Albums.AsQueryable();
        }
    }
}
