using AppFidelidade.Dominio.Cliente.Interface.Aplicacao;
using AppFidelidade.Dominio.Cliente.ViewModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Cliente
{
    [RoutePrefix("api/v1/compra")]
    public class CompraController : BaseController
    {
        private readonly ICompraAplicacao _compraAplicacao;
        public CompraController(ICompraAplicacao compraAplicacao)
        {
            _compraAplicacao = compraAplicacao;
        }
        [Route("obeterBasicoCreditosCliente")]
        [HttpGet]
        public Task<HttpResponseMessage> ObeterBasicoCreditosCliente(int idCliente)
        {
            return CreateResponse(HttpStatusCode.OK, _compraAplicacao.ObeterBasicoCreditosCliente(idCliente));
        }
        [Route("obterBasicoCreditoRetirarCliente")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterBasicoCreditoRetirarCliente(int idCliente)
        {
            return CreateResponse(HttpStatusCode.OK, _compraAplicacao.ObterBasicoCreditoRetirarCliente(idCliente));
        }
        [Route("lancarCompra")]
        [HttpPost]
        public Task<HttpResponseMessage> LancarCompra(LancarCompraViewModel obj)
        {
            return CreateResponse(HttpStatusCode.OK, _compraAplicacao.LancarCompra(obj));
        }
    }
}