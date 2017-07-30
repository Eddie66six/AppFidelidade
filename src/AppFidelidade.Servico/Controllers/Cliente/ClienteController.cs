using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.ViewModel;
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
        public ClienteController(IClienteAplicacao clienteAplicacao) : base()
        {
            _clienteAplicacao = clienteAplicacao;
        }

        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorId(int id)
        {
            return CreateResponse(HttpStatusCode.OK, _clienteAplicacao.ObterPorId(id));
        }
        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorTokenId(string tokenId, int idFilial)
        {
            return CreateResponse(HttpStatusCode.OK, _clienteAplicacao.ObeterPorTokenId(tokenId, idFilial));
        }
        [AllowAnonymous]
        [Route("adicionar")]
        [HttpPost]
        public Task<HttpResponseMessage> Adicionar(ClienteBasicoViewModel cliente)
        {
            return CreateResponse(HttpStatusCode.OK, _clienteAplicacao.Adicionar(cliente));
        }
    }
}