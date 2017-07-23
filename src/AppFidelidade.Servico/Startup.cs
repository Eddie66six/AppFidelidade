using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(AppFidelidade.Servico.Startup))]

namespace AppFidelidade.Servico
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthServerOptions;
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthServerOptions = new OAuthAuthorizationServerOptions();
            //{
                //AllowInsecureHttp = true,
                //TokenEndpointPath = new PathString("/token"),
                //AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //Provider = new SimpleAuthorizationServerProvider()
            //};

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
