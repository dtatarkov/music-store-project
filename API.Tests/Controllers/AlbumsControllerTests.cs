using API.Context;
using API.Controllers;
using API.DTO;
using API.Entities;
using API.Extensions;
using API.MockData;
using API.Services;
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
            var updatedAlbumData = AlbumsMockData.updatedAlbumDTO;
            var updatedAlbum = updatedAlbumData.ToAlbum();

            var applicationContextMock = new Mock<IApplicationContext>();

            var albumsServiceMock = new Mock<IAlbumsService>();
            albumsServiceMock.Setup(m => m.UpdateAlbumAsync(updatedAlbumData)).Returns(Task.FromResult(updatedAlbum));
            albumsServiceMock.Setup(m => m.GetAlbumByIdAsync(updatedAlbum.AlbumId)).Returns(Task.FromResult((Album?)updatedAlbum));

            var controller = new AlbumsController(applicationContextMock.Object, albumsServiceMock.Object);
            var savedAlbum = await controller.Put(updatedAlbumData);

            applicationContextMock.Verify(m => m.SaveChangesAsync(default));

            Assert.NotNull(savedAlbum);
            Assert.Equal(updatedAlbumData.AlbumId, savedAlbum!.AlbumId);
            Assert.Equal(updatedAlbumData.Title, savedAlbum!.Title);
            Assert.Equal(updatedAlbumData.Description, savedAlbum!.Description);
        }
    }
}
