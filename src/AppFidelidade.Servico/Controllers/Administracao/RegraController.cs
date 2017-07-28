using AppFidelidade.Dominio.Administracao.Enum;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.ViewModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Administracao
{
    [Authorize]
    [RoutePrefix("api/v1/regra")]
    public class RegraController : BaseController
    {
        private readonly IRegraAplicacao _regraAplicacao;
        public RegraController(IRegraAplicacao regraAplicacao):base()
        {
            _regraAplicacao = regraAplicacao;
        }
        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterTodos(int idFilial, int take, int skip)
        {
            return CreateResponse(HttpStatusCode.OK, _regraAplicacao.ObterTodos(idFilial, take, skip));
        }
        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorId(int idRegra)
        {
            return CreateResponse(HttpStatusCode.OK, _regraAplicacao.ObterPorId(idRegra));
        }
        [Route("adicionar")]
        [HttpPost]
        public Task<HttpResponseMessage> Adicionar(RegraBasicoViewModel obj)
        {
            return CreateResponse(HttpStatusCode.OK, _regraAplicacao.Adicionar(obj));
        }
        [Route("obterPorDesconto")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorTipoDesconto(int idFilial, ETipoDesconto tipo, int take, int skip)
        {
            return CreateResponse(HttpStatusCode.OK, _regraAplicacao.ObterPorTipoDesconto(idFilial, tipo, take, skip));
        }
        [Route("obterPorValor")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal, int take, int skip)
        {
            return CreateResponse(HttpStatusCode.OK, _regraAplicacao.ObterPorValorInicialFinal(idFilial, valorInicial, valorFinal, take, skip));
        }
    }
}