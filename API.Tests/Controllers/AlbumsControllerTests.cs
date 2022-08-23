using API.Controllers;
using API.Entities;
using API.Services;
using Moq;

namespace API.Tests.Controllers
{
    public class AlbumsControllerTests
    {
        [Fact]
        public void Get()
        {
            var data = new List<Album>
            {
                new Album { AlbumId = 1 },
                new Album { AlbumId = 2 },
                new Album { AlbumId = 3 },
            }.AsQueryable();

            var mockAlbumsService = new Mock<IAlbumsService>();
            mockAlbumsService.Setup(c => c.GetAlbums()).Returns(data);

            var controller = new AlbumsController(mockAlbumsService.Object);
            var albums = controller.Get().ToArray();

            Assert.Equal(3, albums.Length);
            Assert.Equal(1, albums[0].AlbumId);
            Assert.Equal(2, albums[1].AlbumId);
            Assert.Equal(3, albums[2].AlbumId);
        }
    }
}
