using API.DTO;
using API.Entities;

namespace API.Services
{
    public interface IAlbumsService
    {
        IQueryable<Album> GetAlbums();
        Task<Album?> GetAlbumByIdAsync(long albumId);
        Album AddAlbum(NewAlbumDTO data);
        Task<Album> UpdateAlbumAsync(long albumId, AlbumUpdateDTO data);
        Task<Album> RemoveAlbumAsync(long albumId);
    }
}