using API.Entities;
using API.Expressions;
using API.MockData;

namespace API.Tests.Expressions
{
    public class AlbumExpressionsTests
    {
        [Fact]
        public void ToDTOTest()
        {
            var album = AlbumsMockData.albumWithAllFieldsFilled;

            var albumDTO = AlbumExpressions.ToDTO.Compile().Invoke(album);

            Assert.Equal(album.AlbumId, albumDTO.AlbumId);
            Assert.Equal(album.Title, album.Title);
            Assert.Equal(album.Description, albumDTO.Description);
            Assert.Equal(album.CreatedDate, albumDTO.CreatedDate);
            Assert.Equal(album.UpdatedDate, albumDTO.UpdatedDate);            
        }
    }
}
