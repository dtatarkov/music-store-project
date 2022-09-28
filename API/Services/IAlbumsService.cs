using API.DTO;
using API.Entities;

namespace API.Services
{
    public interface IAlbumsService
    {
        IQueryable<Album> GetAlbums();
        Task<Album?> GetAlbumByIdAsync(long albumId);
        Album AddAlbum(AlbumUpdateDTO data);
        Task<Album> UpdateAlbumAsync(long albumId, UpdatedAlbumDTO data);
        Task<Album> RemoveAlbumAsync(long albumId);
    }
}