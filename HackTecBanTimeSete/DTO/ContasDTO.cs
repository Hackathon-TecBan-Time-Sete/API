using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.DTO
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Account2
    {
        public string SchemeName { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }

    }

    public class Account3
    {
        public string AccountId { get; set; }
        public string Currency { get; set; }
        public string Nickname { get; set; }
        public string AccountType { get; set; }
        public string AccountSubType { get; set; }
        public List<Account3> Account { get; set; }

    }

    public class Data2
    {
        public List<Account3> Account { get; set; }

    }

    public class Links2
    {
        public string Self { get; set; }

    }

    public class Meta2
    {
        public int TotalPages { get; set; }

    }

    public class MyArray
    {
        public Data2 Data { get; set; }
        public Links2 Links { get; set; }
        public Meta2 Meta { get; set; }

    }

    public class ContasDTO
    {
        public List<MyArray> MyArray { get; set; }

    }


}
