using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using Microsoft.Owin.Security;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers
{
    public abstract class BaseController : ApiController
    {
        private HttpResponseMessage _responseMessage;
        protected BaseController()
        {
            DomainEvent._domainNotificationHandler = new DomainNotificationHandler();
            _responseMessage = new HttpResponseMessage();
        }
        protected Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            _responseMessage = DomainEvent._domainNotificationHandler.HasNotifications()
                ? Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = DomainEvent._domainNotificationHandler.Notify() })
                : Request.CreateResponse(code, result);
            return Task.FromResult(_responseMessage);
        }
        protected static AuthenticationTicket ConfigureAuthenticationTicket(ClaimsIdentity identity)
        {
            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            var currentUtc = DateTime.UtcNow;
            ticket.Properties.AllowRefresh = true;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.AddDays(3);
            return ticket;
        }
    }
}