using API.DTO;
using API.Extensions;
using API.MockData;

namespace API.Tests.Extensions
{
    public class AlbumExtensionsTests
    {
        [Fact]
        public void ToAlbum_New()
        {
            var newAlbumDTO = AlbumsMockData.newAlbumDTO;
            var album = newAlbumDTO.ToAlbum();

            Assert.Equal(newAlbumDTO.Title, album.Title);
            Assert.Equal(newAlbumDTO.Description, album.Description);
        }

        [Fact]
        public void ToAlbum_Update()
        {
            var updatedAlbumDTO = AlbumsMockData.updatedAlbumDTO;
            var album = updatedAlbumDTO.ToAlbum();

            Assert.Equal(updatedAlbumDTO.AlbumId, album.AlbumId);
            Assert.Equal(updatedAlbumDTO.Title, album.Title);
            Assert.Equal(updatedAlbumDTO.Description, album.Description);
        }
    }
}
