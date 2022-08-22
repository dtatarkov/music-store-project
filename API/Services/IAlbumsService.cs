using API.Entities;

namespace API.Services
{
    public interface IAlbumsService
    {
        IQueryable<Album> GetAlbums();
    }
}