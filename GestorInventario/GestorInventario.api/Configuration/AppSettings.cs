using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Configuration
{
    public class AppSettings
    {
        public TokenManager TokenManager { get; set; }
    }

    public class TokenManager
    {
        public string Secret { get; set; }
        public int AccessExpiration { get; set; }
    }
}
