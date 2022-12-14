using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Settings
{
    public class AppSettings
    {
        public DBSettings DB { get; set; } = new DBSettings();

        public AppSettings(IConfiguration configuration)
        {
            configuration.GetSection("DB").Bind(DB);
        }
    }
}
