using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppFidelidade_App_Client.Authentication;
using AppFidelidade_App_Client.Droid.Authentication;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using AppFidelidade_App_Client.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace AppFidelidade_App_Client.Droid.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider, IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}