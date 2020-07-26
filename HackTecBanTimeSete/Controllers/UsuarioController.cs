using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HackTecBanTimeSete.Models;
using Microsoft.AspNetCore.Authorization;
using HackTecBanTimeSete.Repository;
using HackTecBanTimeSete.DTO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Cors;

namespace HackTecBanTimeSete.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioRepository _repUser;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository repUser)
        {
            _logger = logger;
            _repUser = repUser;
        }


        public IActionResult Index()
        {
            return View();
        }



        /// <summary> Aqui vc cadastra um usuario na plataforma</summary>
        /// <response code="200">Sucesso</response>
        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/user/CadUsuario")]
        public async Task CadUsuario([FromBody] UsuarioCadDTO user)
        {
            await _repUser.CadUsuario(user);
        }


        /// <summary> Aqui vc deleta um usuario na plataforma</summary>
        /// <response code="200">Sucesso</response>
        [HttpDelete]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/user/DelUsuario")]
        public async Task DelUsuario([FromBody] UsuarioDelDTO user)
        {
            await _repUser.DelUsuario(user);
        }

        /// <summary> Aqui vc pega um usuario na plataforma pelo email</summary>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/user/GetUsuarioPorEmail")]
        public async Task GetUsuarioPorEmail([FromBody] UsuarioPorEmailDTO user)
        {
            await _repUser.GetUsuarioPorEmail(user);
        }

        /// <summary> Aqui vc pega um usuario da plataforma</summary>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/user/GetUsuario")]
        public Speaker GetUsuario()
        {
            Speaker s = new Speaker()
            {
                title = "Agrilcultor",
                about = "Solicitação de crédito agropecuário.",
                name = "Augusto Bondança",
                email = "augusto@gmail.com",
                location = "São paulo - SP",
                phone = "+55(11)95068-6369",
                id = "1"
            };
            return s;
        }

        /// <summary> Aqui vc salva uma schedule da plataforma</summary>
        /// <response code="200">Sucesso</response>
        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/user/SetUsuarioSchedulle")]
        public void SetUsuarioSchedulle([FromBody] ScheduleDTO s)
        {
            _repUser.SetUsuarioSchedulle(s);
        }

        /// <summary> Aqui vc pega as schedule na plataforma</summary>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/user/GetUsuarioSchedulle")]
        public List<ScheduleDTO> GetUsuarioSchedulle()
        {
            return _repUser.GetUsuarioSchedulle();
        }

        /// <summary> Aqui vc cadastra uma documentação na plataforma</summary>
        /// <response code="200">Sucesso</response>
        [HttpPost]
        [Route("/api/v1/user/CadDocumento")]
        public void CadDocumento([FromBody] DocumentoDTO doc)
        {
            Documento d = new Documento() 
            {
                DataColheita = doc.DataColheita,
                DataPlantacao = doc.DataPlantacao,
                Email = doc.Email,
                Nome = doc.Nome,
                NomeProduto = doc.NomeProduto,
                Endereco = doc.Endereco,
            };

            _repUser.CadDocumento(d);
        }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
