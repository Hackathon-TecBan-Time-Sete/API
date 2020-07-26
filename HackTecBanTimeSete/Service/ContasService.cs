using HackTecBanTimeSete.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Service
{
    public interface IContasService
    {
        Task<string> GetContas();
    }

    public class ContasService : IContasService
    {


        public async Task<string> GetContas()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api-agroban.herokuapp.com/accounts");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }



    }
}
