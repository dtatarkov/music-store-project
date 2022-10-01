using Client.DTO;
using Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientSettingsController : ControllerBase
    {
        private readonly IClientSettingsService clientSettingsService;

        public ClientSettingsController(IClientSettingsService clientSettingsService)
        {
            this.clientSettingsService = clientSettingsService;
        }

        [HttpGet]
        public ClientSettings Get() => clientSettingsService.GetSettings();
    }
}
