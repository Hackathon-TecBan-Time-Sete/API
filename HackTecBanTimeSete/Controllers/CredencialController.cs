using HackTecBanTimeSete.DTO;
using HackTecBanTimeSete.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Controllers
{
    public class CredencialController: Controller
    {

        private readonly ICredencialService _serv;

        public CredencialController(ICredencialService serv)
        {
            _serv = serv;
        }


        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public async Task<CredencialTokenBancoDTO> GetCredencialBanco([FromBody] CredTipoBancoDTO credTipoBanco)
        {
            return await _serv.GetCredencialBanco(credTipoBanco);
        }




    }
}
