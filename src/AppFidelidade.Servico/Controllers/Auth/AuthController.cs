using AppFidelidade.Dominio._Comum.Interface.Applicacao;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Auth
{
    [Authorize]
    [RoutePrefix("api/v1/auth")]
    public class AuthController : BaseController
    {
        private readonly IAuthAplicacao _authAplicacao;
        public AuthController(IAuthAplicacao authAplicacao):base()
        {
            _authAplicacao = authAplicacao;
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("funcionario")]
        public Task<HttpResponseMessage> LoginFuncionario(string usuario, string senha)
        {
            var funcionario = _authAplicacao.funcionario(usuario, senha);
            if (funcionario == null)
                return CreateResponse(HttpStatusCode.OK, null);

            var identity = new ClaimsIdentity("Bearer");

            var ticket = ConfigureAuthenticationTicket(identity);
            var token = Startup.OAuthServerOptions.AccessTokenFormat.Protect(ticket);
            return CreateResponse(HttpStatusCode.OK, new { Funcionario = funcionario, LoginData = new { Token = token, ExpiresIn = ticket.Properties.ExpiresUtc } });
        }
    }
}