using API.DTO;
using API.Expressions;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        [HttpGet]
        public IQueryable<AlbumDTO> Get() => albumsService.GetAlbums().Select(AlbumExpressions.ToDTO);
    }
}
