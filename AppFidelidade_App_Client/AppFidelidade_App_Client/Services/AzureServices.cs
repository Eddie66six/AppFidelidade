using AppFidelidade_App_Client.Authentication;
using AppFidelidade_App_Client.Helpers;
using AppFidelidade_App_Client.Models.AzureAuth;
using AppFidelidade_App_Client.Services;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AzureServices))]
namespace AppFidelidade_App_Client.Services
{
    public class AzureServices
    {
        FacebookApi facebookApi;
        private static readonly string BaseUrl = "http://g2xappfidelidade.azurewebsites.net";
        List<AppServiceIdentity> identities = null;
        public MobileServiceClient Client { get; set; }

        public void Initialize()
        {
            facebookApi = DependencyService.Get<FacebookApi>();
            Client = new MobileServiceClient(BaseUrl + "/.auth/login/facebook/callback");
            if(!string.IsNullOrEmpty(Settings.AuthToken) && !string.IsNullOrEmpty(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);
            if(user == null)
            {
                Settings.Nome = string.Empty;
                Settings.Id = string.Empty;
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;
                Settings.Foto = string.Empty;
                return false;
            }
            identities = await Client.InvokeApiAsync<List<AppServiceIdentity>>("/.auth/me");
            Settings.Nome = identities[0].UserClaims.Find(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")).Value;
            Settings.Id = identities[0].UserClaims.Find(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")).Value;
            Settings.AuthToken = user.MobileServiceAuthenticationToken;
            Settings.UserId = user.UserId;
            Settings.TokenAuth = identities[0].AccessToken;
            Settings.Foto = await facebookApi.ObterFotoPerfil(Settings.TokenAuth);
            Settings.LoginDate = DateTime.UtcNow.ToString("dd/MM/yyyy");
            return true;
        }
    }
}
