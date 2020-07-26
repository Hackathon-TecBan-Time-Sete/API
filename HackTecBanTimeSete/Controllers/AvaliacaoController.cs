using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackTecBanTimeSete.DTO;
using HackTecBanTimeSete.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HackTecBanTimeSete.Controllers
{
    public class AvaliacaoController : Controller
    {

        private readonly IAvaliacaoRepository _rep;

        public AvaliacaoController(IAvaliacaoRepository rep)
        {
            _rep = rep;
        }


        /// <summary> Aqui vc cadastra uma avaliacão na plataforma</summary>
        /// <response code="200">Sucesso</response>
        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/avaliacao/SetAvaliacao")]
        public void SetAvaliacao(AvaliacaoDTO avaliacao) 
        {
            _rep.SetAvaliacao(avaliacao);
        }


    }
}
