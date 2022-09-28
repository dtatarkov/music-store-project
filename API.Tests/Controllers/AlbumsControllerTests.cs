using API.Context;
using API.Controllers;
using API.DTO;
using API.Entities;
using API.Extensions;
using API.MockData;
using API.Services;
using MockQueryable.Moq;
using Moq;

namespace API.Tests.Controllers
{
    public class AlbumsControllerTests
    {
        [Fact]
        public void Get()
        {
            var applicationContextMock = new Mock<IApplicationContext>();

            var albumsServiceMock = new Mock<IAlbumsService>();
            albumsServiceMock.Setup(c => c.GetAlbums()).Returns(AlbumsMockData.albums);

            var controller = new AlbumsController(applicationContextMock.Object, albumsServiceMock.Object);
            var albums = controller.Get().ToArray();

            Assert.Equal(3, albums.Length);
            Assert.Equal(1, albums[0].AlbumId);
            Assert.Equal(2, albums[1].AlbumId);
            Assert.Equal(3, albums[2].AlbumId);
        }

        [Fact]
        public async Task Post()
        {
            var newAlbumData = AlbumsMockData.newAlbumDTO;
            var newAlbum = newAlbumData.ToAlbum();

            var applicationContextMock = new Mock<IApplicationContext>();

            var albumsServiceMock = new Mock<IAlbumsService>();
            albumsServiceMock.Setup(m => m.AddAlbum(newAlbumData)).Returns(newAlbum);
            albumsServiceMock.Setup(m => m.GetAlbumByIdAsync(newAlbum.AlbumId)).Returns(Task.FromResult((Album?)newAlbum));

            var controller = new AlbumsController(applicationContextMock.Object, albumsServiceMock.Object);
            var savedAlbum = await controller.Post(newAlbumData);

            applicationContextMock.Verify(m => m.SaveChangesAsync(default));
            
            Assert.NotNull(savedAlbum);
            Assert.Equal(newAlbumData.Title, savedAlbum!.Title);
            Assert.Equal(newAlbumData.Description, savedAlbum!.Description);
        }

        [Fact]
        public async Task Put()
        {
            var albumId = 1;

            var albumUpdateData = AlbumsMockData.updatedAlbumDTO;
            var updatedAlbum = albumUpdateData.ToAlbum(albumId);

            var applicationContextMock = new Mock<IApplicationContext>();

            var albumsServiceMock = new Mock<IAlbumsService>();
            albumsServiceMock.Setup(m => m.UpdateAlbumAsync(albumId, albumUpdateData)).Returns(Task.FromResult(updatedAlbum));
            albumsServiceMock.Setup(m => m.GetAlbumByIdAsync(updatedAlbum.AlbumId)).Returns(Task.FromResult((Album?)updatedAlbum));

            var controller = new AlbumsController(applicationContextMock.Object, albumsServiceMock.Object);
            var savedAlbum = await controller.Put(albumId, albumUpdateData);

            applicationContextMock.Verify(m => m.SaveChangesAsync(default));

            Assert.NotNull(savedAlbum);
            Assert.Equal(albumId, savedAlbum!.AlbumId);
            Assert.Equal(albumUpdateData.Title, savedAlbum!.Title);
            Assert.Equal(albumUpdateData.Description, savedAlbum!.Description);
        }

        public async Task Delete()
        {
            var albumId = 1;

            var dbSetMock = AlbumsMockData.albums.BuildMockDbSet();
            var removedAlbum = AlbumsMockData.albums.First(a => a.AlbumId == albumId);

            var contextMock = new Mock<IApplicationContext>();
            contextMock.Setup(c => c.Albums).Returns(dbSetMock.Object);

            var albumsServiceMock = new Mock<IAlbumsService>();
            albumsServiceMock.Setup(m => m.RemoveAlbumAsync(albumId)).Returns(Task.FromResult(removedAlbum));

            var controller = new AlbumsController(contextMock.Object, albumsServiceMock.Object);
            await controller.Delete(albumId);

            albumsServiceMock.Verify(m => m.RemoveAlbumAsync(albumId));
            contextMock.Verify(m => m.SaveChangesAsync(default));
        }
    }
}
