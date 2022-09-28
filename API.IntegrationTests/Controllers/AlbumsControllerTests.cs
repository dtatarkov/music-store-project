using API.DTO;
using API.MockData;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace API.IntegrationTests.Controllers
{
    public class AlbumsControllerTests: IAsyncDisposable
    {
        private readonly TestsApplication app;
        private readonly HttpClient client;

        public AlbumsControllerTests()
        {
            app = new TestsApplication();
            client = app.CreateClient();
        }

        [Fact]
        public async Task Get()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/v1/albums/");
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [MemberData(nameof(AlbumsMockData.GetAlbumsSavingTestDataSetGenerator), MemberType = typeof(AlbumsMockData))]
        public async Task Post(NewAlbumDTO newAlbumData, HttpStatusCode expectedStatusCode)
        {
            var request = new HttpRequestMessage(new HttpMethod("Post"), "/v1/albums/");
            request.Content = new StringContent(JsonConvert.SerializeObject(newAlbumData), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            Assert.Equal(expectedStatusCode, response.StatusCode);

            if (expectedStatusCode == HttpStatusCode.OK)
            {
                var exception = await Record.ExceptionAsync(async () =>
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var savedAlbum = JsonConvert.DeserializeObject<AlbumDTO>(responseContent);

                    Assert.Equal(newAlbumData.Title, savedAlbum.Title);
                    Assert.Equal(newAlbumData.Description, savedAlbum.Description);
                });

                Assert.Null(exception);
            }
        }

        public async ValueTask DisposeAsync()
        {
            client.Dispose();
            await app.DisposeAsync();            
        }
    }
}
