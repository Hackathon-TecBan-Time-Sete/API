using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackTecBanTimeSete.Areas.Identity.Data;
using HackTecBanTimeSete.DTO;
using HackTecBanTimeSete.Exceptions;
using HackTecBanTimeSete.Models;
using HackTecBanTimeSete.Repository;
using HackTecBanTimeSete.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HackTecBanTimeSete.Controllers
{
    public class LoginController : Controller
    {

        private readonly UserManager<HackTecBanTimeSeteUser> _userManager;
        private readonly SignInManager<HackTecBanTimeSeteUser> _signInManager;
        private readonly ILogger<LoginController> _logger;
        private readonly IUsuarioRepository _rep;

        public LoginController(UserManager<HackTecBanTimeSeteUser> userManager, SignInManager<HackTecBanTimeSeteUser> signInManager, ILogger<LoginController> logger, IUsuarioRepository rep)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _rep = rep;
        }

        /// <summary> Aqui vc faz o login no sistema e pega um Bearer Token JWT</summary>
        /// <param name="user"></param>
        /// <returns> O DTO (Data Transfer Object) de UsuarioLoginDTO</returns>
        /// <response code="200">Sucesso</response>
        [HttpPost]
        [AllowAnonymous]
        [Route("/api/v1/user/GetTokenLogin")]
        [EnableCors("AllowAllOrigins")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<TokenUserDTO> GetTokenLogin([FromBody] UsuarioLoginDTO user)
        {
            try
            {
                /* FAZ O LOGIN */
                var userExists = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, false);

                TokenUserDTO token = null;
                if (userExists.Succeeded)
                {
                    /* Ele existe... logo loga... */
                    Usuario usuario = await _rep.GetUsuarioPorEmail(new UsuarioPorEmailDTO()
                        { 
                            Email = user.Email
                        });

                    var tokenGerado = GetAuth.GenerateToken(usuario);
                    token = new TokenUserDTO()
                    {
                        Token = tokenGerado,
                    };
                    return token;
                }
                else 
                {
                    throw new UsuarioNaoEncontradoException("usuario nao encontrado");
                }
            }
            catch (Exception e)
            {
                return new TokenUserDTO()
                {
                    Token = "Ocorreu algum erro interno na aplicação, por favor tente novamente... Erro: " + e.Message,
                };
            }
        }


    }
}
