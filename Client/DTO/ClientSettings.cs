using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DTO
{
    public class ClientSettings
    {
        public ClientAPISettings API { get; set; } = new ClientAPISettings();
    }
}
