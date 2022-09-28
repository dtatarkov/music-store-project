using API.DTO;
using API.MockData;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace API.IntegrationTests.Controllers
{
    public class AlbumsControllerTests
    {
        [Fact]
        public async Task Get()
        {
            using var app = new TestsApplication();
            using var client = app.CreateClient();

            var request = new HttpRequestMessage(new HttpMethod("GET"), "/v1/albums/");
            var response = await client.SendAsync(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var albums = await response.Content.ReadFromJsonAsync<AlbumDTO[]>();

            Assert.NotNull(albums);
            Assert.Equal(3, albums!.Length);
        }

        [Theory]
        [MemberData(nameof(AlbumsMockData.GetAlbumsSavingTestDataSetGenerator), MemberType = typeof(AlbumsMockData))]
        public async Task Post(NewAlbumDTO newAlbumData, HttpStatusCode expectedStatusCode)
        {
            using var app = new TestsApplication();
            using var client = app.CreateClient();

            var request = new HttpRequestMessage(new HttpMethod("Post"), "/v1/albums/");
            request.Content = new StringContent(JsonConvert.SerializeObject(newAlbumData), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            Assert.Equal(expectedStatusCode, response.StatusCode);

            if (expectedStatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var savedAlbum = JsonConvert.DeserializeObject<AlbumDTO>(responseContent);

                Assert.Equal(newAlbumData.Title, savedAlbum.Title);
                Assert.Equal(newAlbumData.Description, savedAlbum.Description);
            }
        }
    }
}
