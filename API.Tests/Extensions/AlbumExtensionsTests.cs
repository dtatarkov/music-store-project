using API.DTO;
using API.Extensions;
using API.MockData;

namespace API.Tests.Extensions
{
    public class AlbumExtensionsTests
    {
        [Fact]
        public void ToAlbum()
        {
            var newAlbumDTO = AlbumsMockData.newAlbumDTO;

            var album = newAlbumDTO.ToAlbum();

            Assert.Equal(newAlbumDTO.Title, album.Title);
            Assert.Equal(newAlbumDTO.Description, album.Description);
        }
    }
}
