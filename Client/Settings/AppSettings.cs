using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Settings
{
    public class AppSettings
    {
        public APISettings API { get; set; } = new APISettings();

        public AppSettings(IConfiguration configuration)
        {
            configuration.GetSection("API").Bind(API);
        }
    }
}
