using API.Context;
using API.DTO;
using API.Expressions;
using API.Extensions;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AlbumsController : ControllerBase
    {
        private readonly IApplicationContext applicationContext;
        private readonly IAlbumsService albumsService;

        public AlbumsController(IApplicationContext applicationContext, IAlbumsService albumsService)
        {
            this.applicationContext = applicationContext;
            this.albumsService = albumsService;
        }

        [HttpGet]
        public IQueryable<AlbumDTO> Get() => albumsService.GetAlbums().Select(AlbumExpressions.ToDTO);

        [HttpPost]
        public async Task<AlbumDTO> Post(AlbumUpdateDTO data)
        {
            var album = albumsService.AddAlbum(data);
            await applicationContext.SaveChangesAsync();

            return (await albumsService.GetAlbumByIdAsync(album.AlbumId))!.ToDTO();
        }

        [HttpPut]
        [Route("{albumId:long}")]
        public async Task<AlbumDTO> Put(long albumId, UpdatedAlbumDTO data)
        {
            var album = await albumsService.UpdateAlbumAsync(albumId, data);
            await applicationContext.SaveChangesAsync();

            return (await albumsService.GetAlbumByIdAsync(album.AlbumId))!.ToDTO();
        }

        [HttpDelete]
        [Route("{albumId:long}")]
        public async Task Delete(long albumId)
        {
            await albumsService.RemoveAlbumAsync(albumId);
            await applicationContext.SaveChangesAsync();
        }
    }
}
