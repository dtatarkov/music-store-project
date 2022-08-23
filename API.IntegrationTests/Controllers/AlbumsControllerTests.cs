using System.Net;

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

        public async ValueTask DisposeAsync()
        {
            client.Dispose();
            await app.DisposeAsync();            
        }
    }
}
