using API.DTO;
using API.Entities;
using System.Net;

namespace API.MockData
{

    public static class AlbumsMockData
    {
        public static Album albumWithAllFieldsFilled = new Album { AlbumId = 3, Title = "Test Title", Description = "Test Description" };

        public static IQueryable<Album> albums = new List<Album>()
        {
            new Album { AlbumId = 1, Title = "Test Title" },
            new Album { AlbumId = 2, Description = "Test Description" },
            albumWithAllFieldsFilled
        }.AsQueryable();

        public static NewAlbumDTO newAlbumDTO = new NewAlbumDTO
        {
            Title = "Test Title",
            Description = "Test Description"
        };

        public static AlbumUpdateDTO updatedAlbumDTO = new AlbumUpdateDTO
        {
            Title = "Updated Test Title",
            Description = "Updated Test Description"
        };

        public static IEnumerable<object[]> GetAlbumsSavingTestDataSetGenerator() {
            yield return new object[] { new NewAlbumDTO { Title = "Test Title", Description = "Test Description" }, HttpStatusCode.OK };
            yield return new object[] { new NewAlbumDTO { Title = "Test Title" }, HttpStatusCode.OK };
            yield return new object[] { new NewAlbumDTO { }, HttpStatusCode.InternalServerError };
        }

        public static IEnumerable<object[]> GetAlbumsUpdateTestDataSetGenerator()
        {
            yield return new object[] { 1, new AlbumUpdateDTO { Title = "Test Title", Description = "Test Description" }, HttpStatusCode.OK };
            yield return new object[] { 1, new AlbumUpdateDTO { Title = "Test Title" }, HttpStatusCode.OK };
            yield return new object[] { 1, new AlbumUpdateDTO { }, HttpStatusCode.InternalServerError };
            yield return new object[] { 0, new AlbumUpdateDTO { Title = "Test Title" }, HttpStatusCode.InternalServerError };
            yield return new object[] { -1, new AlbumUpdateDTO { Title = "Test Title" }, HttpStatusCode.InternalServerError };
        }

        public static IEnumerable<object[]> GetAlbumsRemoveTestDataSetGenerator()
        {
            yield return new object[] { 1, HttpStatusCode.OK };
            yield return new object[] { 0, HttpStatusCode.InternalServerError };
            yield return new object[] { -1, HttpStatusCode.InternalServerError };
        }
    }
}
