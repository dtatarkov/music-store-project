using API.DTO;
using API.Extensions;

namespace API.Tests.Extensions
{
    public class AlbumExtensionsTests
    {
        [Fact]
        public void ToAlbum()
        {
            var newAlbumDTO = new NewAlbumDTO
            {
                Title = "Test Title",
                Description = "Test Description"
            };

            var album = newAlbumDTO.ToAlbum();

            Assert.Equal(newAlbumDTO.Title, album.Title);
            Assert.Equal(newAlbumDTO.Description, album.Description);
        }
    }
}
