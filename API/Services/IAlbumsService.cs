using API.DTO;
using API.Entities;

namespace API.Services
{
    public interface IAlbumsService
    {
        IQueryable<Album> GetAlbums();
        Album? GetAlbumById(int albumId);
        Album AddAlbum(NewAlbumDTO data);
    }
}