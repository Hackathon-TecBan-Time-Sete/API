using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackTecBanTimeSete.Areas.Identity.Data;
using HackTecBanTimeSete.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HackTecBanTimeSete.Data
{
    public class HackTecBanTimeSeteContext : IdentityDbContext<HackTecBanTimeSeteUser>
    {

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Track> Tracks { get; set; }
        public DbSet<Usuario> SessionSchedules { get; set; }
        public DbSet<GroupsSchedule> GroupsSchedules { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }



        public HackTecBanTimeSeteContext(DbContextOptions<HackTecBanTimeSeteContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);





        }
    }
}
