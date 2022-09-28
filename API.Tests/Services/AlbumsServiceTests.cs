using API.Context;
using API.MockData;
using API.Services;
using API.Validators;
using MockQueryable.Moq;
using Moq;

namespace API.Tests.Services
{
    public class AlbumsServiceTests
    {
        private readonly Mock<IAlbumValidator> albumsValidatorMock = new();

        [Fact]
        public void GetAlbums()
        {
            var dbSetMock = AlbumsMockData.albums.BuildMockDbSet();

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
        public async Task GetAlbumByIdAsync_ReturnsExistingEntity()
        {
            var albumId = 1;
            var dbSetMock = AlbumsMockData.albums.BuildMockDbSet();

            var contextMock = new Mock<IApplicationContext>();
            contextMock.Setup(c => c.Albums).Returns(dbSetMock.Object);

            var service = new AlbumsService(contextMock.Object, albumsValidatorMock.Object);
            var album = await service.GetAlbumByIdAsync(albumId);

            Assert.NotNull(album);
            Assert.Equal(albumId, album!.AlbumId);
        }

        [Fact]
        public async Task GetAlbumByIdAsync_ReturnsNullWhenEntityNotFound()
        {
            var albumId = -1;
            var dbSetMock = AlbumsMockData.albums.BuildMockDbSet();

            var contextMock = new Mock<IApplicationContext>();
            contextMock.Setup(c => c.Albums).Returns(dbSetMock.Object);

            var service = new AlbumsService(contextMock.Object, albumsValidatorMock.Object);
            var album = await service.GetAlbumByIdAsync(albumId);

            Assert.Null(album);
        }

        [Fact]
        public void AddAlbum()
        {
            var newAlbumDTO = AlbumsMockData.newAlbumDTO;

            var contextMock = new Mock<IApplicationContext>();

            var service = new AlbumsService(contextMock.Object, albumsValidatorMock.Object);
            var newAlbum = service.AddAlbum(newAlbumDTO);

            contextMock.Verify(m => m.Add(newAlbum));
        }

        [Fact]
        public async Task UpdateAlbumAsync_UpdatesExistingEntity()
        {
            var albumToUpdateId = 1;
            var updatedAlbumDTO = AlbumsMockData.updatedAlbumDTO;

            var dbSetMock = AlbumsMockData.albums.BuildMockDbSet();

            var contextMock = new Mock<IApplicationContext>();
            contextMock.Setup(c => c.Albums).Returns(dbSetMock.Object);

            var service = new AlbumsService(contextMock.Object, albumsValidatorMock.Object);
            var updatedAlbum = await service.UpdateAlbumAsync(albumToUpdateId, updatedAlbumDTO);

            Assert.Equal(albumToUpdateId, updatedAlbum.AlbumId);
            Assert.Equal(updatedAlbumDTO.Title, updatedAlbum.Title);
            Assert.Equal(updatedAlbumDTO.Description, updatedAlbum.Description);
        }

        [Fact]
        public async Task UpdateAlbumAsync_ThrowsErrorWhenEntityNotFound()
        {
            var albumToUpdateId = -1;
            var updatedAlbumDTO = AlbumsMockData.updatedAlbumDTO;

            var dbSetMock = AlbumsMockData.albums.BuildMockDbSet();

            var contextMock = new Mock<IApplicationContext>();
            contextMock.Setup(c => c.Albums).Returns(dbSetMock.Object);

            var service = new AlbumsService(contextMock.Object, albumsValidatorMock.Object);
            var exception = await Record.ExceptionAsync(() => service.UpdateAlbumAsync(albumToUpdateId, updatedAlbumDTO));

            Assert.NotNull(exception);
        }

        [Fact]
        public async Task RemoveAlbumAsync_RemovesExistingEntity()
        {
            var albumId = 1;

            var dbSetMock = AlbumsMockData.albums.BuildMockDbSet();

            var contextMock = new Mock<IApplicationContext>();
            contextMock.Setup(c => c.Albums).Returns(dbSetMock.Object);

            var service = new AlbumsService(contextMock.Object, albumsValidatorMock.Object);
            var removedAlbum = await service.RemoveAlbumAsync(albumId);

            contextMock.Verify(m => m.Remove(removedAlbum));
        }

        [Fact]
        public async Task RemoveAlbumAsync_ThrowsExceptionWhenEntityNotFound()
        {
            var albumId = -1;

            var dbSetMock = AlbumsMockData.albums.BuildMockDbSet();

            var contextMock = new Mock<IApplicationContext>();
            contextMock.Setup(c => c.Albums).Returns(dbSetMock.Object);

            var service = new AlbumsService(contextMock.Object, albumsValidatorMock.Object);
            var exception = await Record.ExceptionAsync(() => service.RemoveAlbumAsync(albumId));

            Assert.NotNull(exception);
        }
    }
}
