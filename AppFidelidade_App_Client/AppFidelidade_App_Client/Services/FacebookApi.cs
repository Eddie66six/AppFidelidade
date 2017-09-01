using AppFidelidade_App_Client.Models.AzureAuth;
using AppFidelidade_App_Client.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(FacebookApi))]
namespace AppFidelidade_App_Client.Services
{
    public class FacebookApi
    {
        private HttpClient client = new HttpClient();
        public FacebookApi()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        /// <summary>
        /// Retorna foto e data de nascimento
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns>foto,data nascimento</returns>
        public async Task<string> ObterFotoPerfil(string userToken)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://graph.facebook.com/v2.10/me?fields=picture.width(200)&access_token={userToken}");
                var result = await response.Content.ReadAsStringAsync();
                if (result == null || (response.StatusCode != System.Net.HttpStatusCode.BadRequest && response.StatusCode != System.Net.HttpStatusCode.OK))
                    return null;
                if (result.Contains("error"))
                    return null;
                else
                {
                    var foto = JsonConvert.DeserializeObject<FacebookProfile>(result);
                    return foto.picture.data.url;
                }
                    
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
