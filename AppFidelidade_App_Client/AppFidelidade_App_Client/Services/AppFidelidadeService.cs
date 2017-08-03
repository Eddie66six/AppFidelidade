using AppFidelidade_App_Client.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppFidelidade_App_Client.Services
{
    public class AppFidelidadeService
    {
        private readonly string _baseUrl = "http://192.168.0.104:3000/";
        private HttpClient client = new HttpClient();
        public AppFidelidadeService()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Tuple<Errors, ClienteBasico>> ClienteBasico(int idCliente)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/cliente/obter?id={idCliente}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null)
                    return new Tuple<Errors, ClienteBasico>(null, null);
                if (result.Contains("errors"))
                    return new Tuple<Errors, ClienteBasico>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, ClienteBasico>(null, JsonConvert.DeserializeObject<ClienteBasico>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Tuple<Errors, ClienteCredito>> ObterCreditoBasico(int idCliente)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/obeterBasicoCreditosCliente/obter?idCliente={idCliente}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null)
                    return new Tuple<Errors, ClienteCredito>(null, null);
                if (result.Contains("errors"))
                    return new Tuple<Errors, ClienteCredito>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, ClienteCredito>(null, JsonConvert.DeserializeObject<ClienteCredito>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<Tuple<Errors, ClienteCreditosRetirar>> ObterCreditoResgatarBasico(int idCliente)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{_baseUrl}api/v1/obterBasicoCreditoRetirarCliente/obter?idCliente={idCliente}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null)
                    return new Tuple<Errors, ClienteCreditosRetirar>(null, null);
                if (result.Contains("errors"))
                    return new Tuple<Errors, ClienteCreditosRetirar>(JsonConvert.DeserializeObject<Errors>(result), null);
                else
                    return new Tuple<Errors, ClienteCreditosRetirar>(null, JsonConvert.DeserializeObject<ClienteCreditosRetirar>(result));
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
