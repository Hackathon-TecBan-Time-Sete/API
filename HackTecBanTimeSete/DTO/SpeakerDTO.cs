using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.DTO
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Speaker
    {
        public string name { get; set; }
        public string about { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string id { get; set; }

    }

    public class SpeakerDTO
    {
        public List<Speaker> speakers { get; set; }

    }
}
