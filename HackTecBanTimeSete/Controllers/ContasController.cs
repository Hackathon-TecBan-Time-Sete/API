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
    public class ContasController: Controller
    {

        private readonly IContasService _serv;

        public ContasController(IContasService serv)
        {
            _serv = serv;
        }


        /// <summary> Aqui vc pega as contas no OpenBank do usuario</summary>
        /// <returns> A lista de contas do usuario</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/contas/GetContas")]
        public async Task<string> GetContas()
        {
            return await _serv.GetContas();
        }



    }
}
