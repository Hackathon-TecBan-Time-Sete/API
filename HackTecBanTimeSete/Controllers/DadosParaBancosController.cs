using HackTecBanTimeSete.Models;
using HackTecBanTimeSete.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Controllers
{
    public class DadosParaBancosController : Controller
    {

        private readonly IDadosParaBancosRepository _rep;

        public DadosParaBancosController(IDadosParaBancosRepository rep)
        {
            _rep = rep;
        }



        /// <summary> Aqui o banco pega uma lista do Sicor (documentos) dos usuários da nossa plataforma</summary>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/banco/GetSicorDeUsuariosToList")]
        public List<Documento> GetSicorDeUsuariosToList()
        {
            return _rep.GetSicorDeUsuariosToList();
        }

        /// <summary> Aqui o banco pega uma lista de avaliação dos usuarios da nossa plataforma</summary>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/banco/GetDadosAvaliacaoUsuariosToList")]
        public List<Avaliacao> GetDadosAvaliacaoUsuariosToList()
        {
            return _rep.GetDadosAvaliacaoUsuariosToList();
        }





    }
}
