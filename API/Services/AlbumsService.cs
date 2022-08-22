using API.Context;
using API.Entities;

namespace API.Services
{
    public class AlbumsService: IAlbumsService
    {
        private readonly ApplicationContext dbContext;

        public AlbumsService(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Album> GetAlbums()
        {
            return dbContext.Albums.AsQueryable();
        }
    }
}
