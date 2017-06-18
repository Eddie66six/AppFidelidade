using AppFidelidadeMobile.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppFidelidadeMobile.Service
{
    public class AppFidelidadeApiService
    {
        private HttpClient Api { get; set; }

        public AppFidelidadeApiService()
        {
            Api = new HttpClient();
            Api.BaseAddress = new Uri("http://192.168.0.104:3000/api/v1/");
            Api.DefaultRequestHeaders.Accept.Clear();
            Api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Cliente> GetCliente(int id)
        {
            try
            {
                var response = await Api.GetAsync($"cliente/obter?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Cliente>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
