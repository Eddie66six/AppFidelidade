using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Cliente
{
    [Authorize]
    [RoutePrefix("api/v1/cliente")]
    public class ClienteController : BaseController
    {
        private readonly IClienteAplicacao _clienteAplicacao;
        public ClienteController(IClienteAplicacao clienteAplicacao):base()
        {
            _clienteAplicacao = clienteAplicacao;
        }

        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorId(int id)
        {
            return CreateResponse(HttpStatusCode.OK, _clienteAplicacao.ObterPorId(id));
        }
    }
}