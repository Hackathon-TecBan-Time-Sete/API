using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.DTO
{
    public class CredencialTokenBancoDTO
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }

    }
}
