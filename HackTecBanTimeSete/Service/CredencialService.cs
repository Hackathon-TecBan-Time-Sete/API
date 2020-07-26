using HackTecBanTimeSete.DTO;
using HackTecBanTimeSete.Token;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HackTecBanTimeSete.Service
{

    public interface ICredencialService
    {
        Task<CredencialTokenBancoDTO> GetCredencialBanco(CredTipoBancoDTO credTipoBanco);
    }

    public class CredencialService : ICredencialService
    {


        private readonly IWebHostEnvironment _environment;

        public CredencialService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<CredencialTokenBancoDTO> GetCredencialBanco(CredTipoBancoDTO credTipoBanco)
        {

            switch (credTipoBanco.bancoId)
            {
                case 1:

                    var envBanco1 = JsonConvert.DeserializeObject<EnviBancoDTO>(File.ReadAllText("Configs/TPP207/Banco_1/postman/environment_TPP207_Banco_1.json"));
                    return await RealizaGetCredencialBanco(envBanco1, credTipoBanco);


                case 2:
                    var envBanco2 = JsonConvert.DeserializeObject<EnviBancoDTO>(File.ReadAllText("Configs/TPP207/Banco_2/postman/environment_TPP207_Banco_2.json"));
                    return await RealizaGetCredencialBanco(envBanco2, credTipoBanco);

                default:
                    return null;
            }

        }


        //public string MakeToken(string kid, string client_id, EnviBancoDTO envBanco1) 
        //{
        //    var KID = "MuhkohmJqv1r66JwYdpTHKE4EahbtDCxlZEW6S_-9_k"; // o sign in
        //    var OIDC_CLIENT_ID = "986b1862-b44f-4b30-bcd9-1803e53f34ce";

        //    var jwt_iat = DateTime.Now;
        //    var jwt_exp = jwt_iat.AddDays(600);
        //    var header = new Dictionary<string, string>
        //    {
        //        { "alg", "PS256" },
        //        { "kid", kid },
        //        { "typ", "JWT" }
        //    };

        //    var V3_ACCT_BASEURL = envBanco1.values.Where(v => v.key.Equals("tokenEndpoint")).FirstOrDefault().value;

        //    var rfc4122bytes = Convert.FromBase64String("aguidthatIgotonthewire=="); // AQUI NO PYTHON TÁ RANDOM
        //    Array.Reverse(rfc4122bytes, 0, 4);
        //    Array.Reverse(rfc4122bytes, 4, 2);
        //    Array.Reverse(rfc4122bytes, 6, 2);
        //    var guid = new Guid(rfc4122bytes);

        //    var claims = new Dictionary<string, string>
        //    {
        //        { "iss", client_id },
        //        { "sub", client_id },
        //        { "aud", V3_ACCT_BASEURL },
        //        { "jti", guid.ToString() },
        //        { "iat", jwt_iat.ToString() },
        //        { "exp", jwt_exp.ToString() }
        //    };

        //    var token = GetAuth.GenerateTokenByStr(guid.ToString(), header, claims);

        //    var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, crt), Path.Combine(_environment.ContentRootPath, key));


        //    key_obj = jwk.JWK.from_pem(PRIVATE_RSA_KEY.encode('latin-1'))
        //    token.make_signed_token(key_obj)
        //    signed_token = token.serialize()


        //}

        /* VARIAVEIS DO PYTHON */
        //var KID = "MuhkohmJqv1r66JwYdpTHKE4EahbtDCxlZEW6S_-9_k"; // o sign in

        //var PRIVATE_RSA_KEY = @"
        //---- - BEGIN RSA PRIVATE KEY---- -

        //    -----END RSA PRIVATE KEY---- -
        //    ";

        //var OIDC_CLIENT_ID = "986b1862-b44f-4b30-bcd9-1803e53f34ce";
        //var OIDC_SECRET = "856d1f96-605f-4102-8cc3-2698466cee49";

        //var TRANSPORT_CERT_KEY = Path.Combine(_environment.ContentRootPath, string.Format("Configs\\TPP207\\Banco_{0}\\certs\\client_private_key.key", credTipoBanco.bancoId));
        //var TRANSPORT_CERT = @"https://tecban-uat-us-east-1-keystore.s3.amazonaws.com/fd4846dc-035d-4bbd-9710-d00a4f94e570/0ad44fe1-e109-4003-9eb6-6b8f0d776ae5/KTMpVt-6wXztNyq4BU2xGnN0g3Ky_Cntz_8n8GZD4bk.pem";

        //var V3_ACCT_BASEURL = envBanco1.values.Where(v => v.key.Equals("tokenEndpoint")).FirstOrDefault().value;
        //var V3_PYMT_BASEURL = ">> https://rs1.o3bank.co.uk/open-banking/v3.1/pisp/ <<";



        private async Task<CredencialTokenBancoDTO> RealizaGetCredencialBanco(EnviBancoDTO envBanco1, CredTipoBancoDTO credTipoBanco)
        {
            try
            {
                                var crt = string.Format("Configs/TPP207/Banco_{0}/certs/client_certificate.crt", credTipoBanco.bancoId);
                                var key = string.Format("Configs/TPP207/Banco_{0}/certs/client_private_key.key", credTipoBanco.bancoId);

                var cert = new X509Certificate2(
                    "https://tecban-uat-us-east-1-keystore.s3.amazonaws.com/fd4846dc-035d-4bbd-9710-d00a4f94e570/0ad44fe1-e109-4003-9eb6-6b8f0d776ae5/KTMpVt-6wXztNyq4BU2xGnN0g3Ky_Cntz_8n8GZD4bk.pem",                    
                    key
                );


                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                handler.ClientCertificates.Add(cert);
//                handler.SslProtocols = SslProtocols.Tls13 | SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;

                var client = new HttpClient(handler);


                /* SETA AS BODY */
                var cont = JsonConvert.SerializeObject(File.ReadAllText("Configs\\Params\\access-token-body.json"));

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(envBanco1.values.Where(v => v.key.Equals("tokenEndpoint")).FirstOrDefault().value),
                    Method = HttpMethod.Post,
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", envBanco1.values.Where(v => v.key.Equals("basicToken")).FirstOrDefault().value);
                request.Content = new StringContent(cont, Encoding.UTF8, "application/x-www-form-urlencoded");

                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CredencialTokenBancoDTO>((responseContent));
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }




    }
}
