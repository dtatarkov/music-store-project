﻿using API.Context;
using API.Entities;
using API.Services;
using MockQueryable.Moq;
using Moq;

namespace API.Tests.Services
{
    public class AlbumsServiceTests
    {
        [Fact]
        public void GetAlbums()
        {
            var data = new List<Album>
            {
                new Album { AlbumId = 1 },
                new Album { AlbumId = 2 },
                new Album { AlbumId = 3 },
            }.AsQueryable();

            var mockSet = data.BuildMockDbSet();

            var mockContext = new Mock<IApplicationContext>();
            mockContext.Setup(c => c.Albums).Returns(mockSet.Object);

            var service = new AlbumsService(mockContext.Object);
            var albums = service.GetAlbums().ToArray();

            Assert.Equal(3, albums.Length);
            Assert.Equal(1, albums[0].AlbumId);
            Assert.Equal(2, albums[1].AlbumId);
            Assert.Equal(3, albums[2].AlbumId);
        }
    }
}
