using AppFidelidade.Infra.Ioc;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace AppFidelidade.Servico
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectContainer.RegistrarIoc());
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
