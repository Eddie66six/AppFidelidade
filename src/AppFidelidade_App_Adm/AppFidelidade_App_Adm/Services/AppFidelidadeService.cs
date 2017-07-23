using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppFidelidade_App_Adm.Services
{
    public static class AppFidelidadeService
    {
        private readonly static string baseUrl = "http://192.168.15.3:3000/";
        static HttpClient client = new HttpClient();
        private static void init(bool addAuth)
        {
            if (addAuth)
            {
                var storage = new StorageService();
                var loginData = storage.ObterLogin();
                var data = JsonConvert.DeserializeObject<Models.FuncionarioLogin>(loginData.LoginData);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", data.LoginData.Token);
            }
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<Models.FuncionarioLogin> FuncionarioLogin(string usuario, string senha)
        {
            try
            {
                init(false);
                HttpResponseMessage response = await client.GetAsync($"{baseUrl}api/v1/auth/funcionario?usuario={usuario}&senha={senha}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var login = JsonConvert.DeserializeObject<Models.FuncionarioLogin>(jsonResult);
                    return login;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
