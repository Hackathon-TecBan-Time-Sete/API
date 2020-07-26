using HackTecBanTimeSete.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Controllers
{
    public class ProdutoController:Controller
    {

        private readonly IProdutoService _serv;

        public ProdutoController(IProdutoService serv)
        {
            _serv = serv;
        }

        /// <summary> Aqui vc pega os produtos no OpenBank dos bancos cadastrados</summary>
        /// <returns> A lista de produtos do usuario</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/produtos/GetProdutos")]
        public async Task<string> GetProdutos()
        {
            return await _serv.GetProdutos();
        }

        /// <summary> Aqui vc realiza a compra de um produto dos bancos cadastrados</summary>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        [Route("/api/v1/produtos/CompraProduto")]
        public async Task<string> CompraProduto()
        {
            return await _serv.GetProdutos();
        }



    }
}
