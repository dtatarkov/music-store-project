using API.Context;
using API.DTO;
using API.Entities;
using API.Services;
using API.Validators;
using MockQueryable.Moq;
using Moq;

namespace API.Tests.Services
{
    public class AlbumsServiceTests
    {
        private readonly Mock<IAlbumValidator> albumsValidatorMock = new Mock<IAlbumValidator>();

        [Fact]
        public void GetAlbums()
        {
            var data = new List<Album>
            {
                new Album { AlbumId = 1 },
                new Album { AlbumId = 2 },
                new Album { AlbumId = 3 },
            }.AsQueryable();

            var dbSetMock = data.BuildMockDbSet();

            var contextMock = new Mock<IApplicationContext>();
            contextMock.Setup(c => c.Albums).Returns(dbSetMock.Object);

            var service = new AlbumsService(contextMock.Object, albumsValidatorMock.Object);
            var albums = service.GetAlbums().ToArray();

            Assert.Equal(3, albums.Length);
            Assert.Equal(1, albums[0].AlbumId);
            Assert.Equal(2, albums[1].AlbumId);
            Assert.Equal(3, albums[2].AlbumId);
        }

        [Fact]
        public void GetAlbumById()
        {
            var data = new List<Album>
            {
                new Album { AlbumId = 1 }
            }.AsQueryable();

            var dbSetMock = data.BuildMockDbSet();

            var contextMock = new Mock<IApplicationContext>();
            contextMock.Setup(c => c.Albums).Returns(dbSetMock.Object);

            var service = new AlbumsService(contextMock.Object, albumsValidatorMock.Object);
            var album = service.GetAlbumById(1);

            Assert.NotNull(album);
            Assert.Equal(1, album!.AlbumId);
        }

        [Fact]
        public void AddAlbum()
        {
            var albumDTO = new NewAlbumDTO();

            var contextMock = new Mock<IApplicationContext>();

            var service = new AlbumsService(contextMock.Object, albumsValidatorMock.Object);
            var album = service.AddAlbum(albumDTO);

            contextMock.Verify(m => m.Add(album));
        }
    }
}
