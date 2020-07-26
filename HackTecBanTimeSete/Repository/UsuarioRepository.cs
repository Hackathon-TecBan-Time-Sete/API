using HackTecBanTimeSete.Areas.Identity.Data;
using HackTecBanTimeSete.Data;
using HackTecBanTimeSete.DTO;
using HackTecBanTimeSete.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Repository
{
    public interface IUsuarioRepository
    {
        Task CadUsuario(UsuarioCadDTO user);
        Task DelUsuario(UsuarioDelDTO user);
        Task<Usuario> GetUsuarioPorEmail(UsuarioPorEmailDTO user);
        void SetUsuarioSchedulle(ScheduleDTO s);
        List<ScheduleDTO> GetUsuarioSchedulle();
        void CadDocumento(Documento doc);
    }


    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly HackTecBanTimeSeteContext _ctx;
        private readonly SignInManager<HackTecBanTimeSeteUser> _signInManager;
        private readonly UserManager<HackTecBanTimeSeteUser> _userManager;
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(HackTecBanTimeSeteContext ctx, SignInManager<HackTecBanTimeSeteUser> signInManager, UserManager<HackTecBanTimeSeteUser> userManager, ILogger<UsuarioRepository> logger)
        {
            _ctx = ctx;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public object Request { get; private set; }

        public void CadDocumento(Documento doc)
        {
            _ctx.Documentos.Add(doc);
            _ctx.SaveChanges();
        }

        public async Task CadUsuario(UsuarioCadDTO user)
        {
            /* Cadastra no AspUsers */
            var usuarioIdt = new HackTecBanTimeSeteUser { UserName = user.Email, Email = user.Email, Tipo = Token.AuthDeUser.Agricultor };
            usuarioIdt.EmailConfirmed = true;
            usuarioIdt.TwoFactorEnabled = false;

            var result = await _userManager.CreateAsync(usuarioIdt, user.Password);
            if (result.Succeeded)
            {

                /* Cadastra na Aplicacao */
                var usuarioNosso = new Usuario()
                {
                    Email = user.Email,
                };

                _ctx.Usuarios.Add(usuarioNosso);
                await _ctx.SaveChangesAsync();
            }
        }

        public async Task DelUsuario(UsuarioDelDTO user)
        {
         
            var usuario = await _ctx.Usuarios
                .Where(u => u.UsuarioId == user.UserId)
                .FirstOrDefaultAsync();
            
            _ctx.Usuarios.Remove(usuario);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Usuario> GetUsuarioPorEmail(UsuarioPorEmailDTO user)
        {
            return await _ctx.Usuarios.Where(u => u.Email.Equals(user.Email)).FirstOrDefaultAsync();
        }

        public List<ScheduleDTO> GetUsuarioSchedulle()
        {
            var lstS = _ctx.Schedules
                .Include(s => s.Groups)
                .ThenInclude(g => g.Sessions)
                .ThenInclude(ss => ss.Tracks)
                .ToList();

            var lstDTO = new List<ScheduleDTO>();
            foreach (Schedule s in lstS) 
            {
            
                ScheduleDTO sd = new ScheduleDTO()
                {
                    Date = s.Date,
                };
                var lstGS = new List<GroupsScheduleDTO>();
                foreach (GroupsSchedule gs in s.Groups)
                {
                    var g = new GroupsScheduleDTO()
                    {
                        Time = gs.Time,
                    };

                    var ses = new List<SessionScheduleDTO>();
                    foreach (SessionSchedule sc in gs.Sessions)
                    {
                        var scEtt = new SessionScheduleDTO()
                        {
                            Id = sc.Id,
                            Location = sc.Location,
                            Name = sc.Name,
                            TimeEnd = sc.TimeEnd,
                            TimeStart = sc.TimeStart,
                        };
                        var lstTracks = new List<string>();

                        foreach (Track t in sc.Tracks)
                        {
                            var track = t.track;

                            lstTracks.Add(track);
                        }
                        scEtt.Tracks = lstTracks;
                        ses.Add(scEtt);
                    }
                    g.Sessions = ses;
                    lstGS.Add(g);
                }
                sd.Groups = lstGS;

                lstDTO.Add(sd);
            }



            return lstDTO;
        }

        public void SetUsuarioSchedulle(ScheduleDTO s)
        {
            Schedule sd = new Schedule()
            {
                Date = s.Date,
            };
            var lstGS = new List<Models.GroupsSchedule>();
            foreach(GroupsScheduleDTO gs in s.Groups)
            {            
                var g = new GroupsSchedule()
                {
                    Time = gs.Time,
                };
                
                var ses = new List<Models.SessionSchedule>();
                foreach (SessionScheduleDTO sc in gs.Sessions) 
                {
                    var scEtt = new Models.SessionSchedule()
                    {
                        Id = sc.Id,
                        Location = sc.Location,
                        Name = sc.Name,
                        TimeEnd = sc.TimeEnd,
                        TimeStart = sc.TimeStart,
                    };
                    var lstTracks = new List<Track>(); 

                    foreach (string t in sc.Tracks) 
                    {
                        Track tr = new Track()
                        {
                            track = t,
                        };

                        lstTracks.Add(tr);
                    }
                    scEtt.Tracks = lstTracks;
                    ses.Add(scEtt);
                }
                g.Sessions = ses;
                lstGS.Add(g);
            }
            sd.Groups = lstGS;


             _ctx.Schedules.Add(sd);
             _ctx.SaveChanges();
        }


    }
}
