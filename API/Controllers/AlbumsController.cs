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
        public async Task<AlbumDTO> Post(NewAlbumDTO data)
        {
            var album = albumsService.AddAlbum(data);
            await applicationContext.SaveChangesAsync();

            return (await albumsService.GetAlbumByIdAsync(album.AlbumId))!.ToDTO();
        }

        [HttpPut]
        public async Task<AlbumDTO> Put(UpdatedAlbumDTO data)
        {
            var album = await albumsService.UpdateAlbumAsync(data);
            await applicationContext.SaveChangesAsync();

            return (await albumsService.GetAlbumByIdAsync(album.AlbumId))!.ToDTO();
        }
    }
}
