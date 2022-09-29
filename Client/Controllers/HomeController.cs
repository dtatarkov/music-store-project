using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment environment;

        public HomeController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public IActionResult Index(string url)
        {
            var path = Path.Combine(environment.WebRootPath, "dist", "index.html");
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            return new FileStreamResult(stream, "text/html");
        }
    }
}