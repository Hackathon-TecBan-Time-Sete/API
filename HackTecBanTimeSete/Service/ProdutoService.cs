using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Service
{
    public interface IProdutoService
    {
        Task<string> GetProdutos();
    }

    public class ProdutoService : IProdutoService
    {
        public async Task<string> GetProdutos()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://api-agroban.herokuapp.com/accounts");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

    }
}
