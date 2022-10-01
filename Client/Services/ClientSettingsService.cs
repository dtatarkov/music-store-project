using Client.DTO;
using Client.Settings;

namespace Client.Services
{
    public class ClientSettingsService: IClientSettingsService
    {
        private readonly AppSettings settings;

        public ClientSettingsService(AppSettings settings)
        {
            this.settings = settings;
        }

        public ClientSettings GetSettings()
        {
            return new ClientSettings
            {
                API = new ClientAPISettings
                {
                    URL = settings.API.PublicURL
                }
            };
        }
    }
}
