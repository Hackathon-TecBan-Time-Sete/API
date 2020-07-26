using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Models
{
    public class Documento
    {
        public int DocumentoId { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string NomeProduto { get; set; }
        public string DataPlantacao { get; set; }
        public string DataColheita { get; set; }
        public string Endereco { get; set; }

    }
}
