using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.DTO
{
    public class CredTipoBancoDTO
    {
        [Required]
        public int bancoId { get; set; }
    }
}
