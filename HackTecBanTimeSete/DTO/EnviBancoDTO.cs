using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.DTO
{
    public class EnviBancoDTO
    {
        public string id { get; set; }
        public string version { get; set; }
        public List<EnviBancoValueDTO> values { get; set; }
        public long timestamp { get; set; }
        public string _postman_variable_scope { get; set; }
        public DateTime _postman_exported_at { get; set; }
        public string _postman_exported_using { get; set; }
        public string name { get; set; }

    }
}
