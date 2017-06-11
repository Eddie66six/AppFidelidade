using AppFidelidade.Aplicacao.Aplicacao.Administracao;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Enum;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Administracao
{
    [RoutePrefix("api/v1/regra")]
    public class RegraController : BaseController
    {
        private readonly RegraAplicacao _regraAplicacao;
        public RegraController(RegraAplicacao regraAplicacao)
        {
            _regraAplicacao = regraAplicacao;
        }
        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterTodos(int idFilial)
        {
            return CreateResponse(HttpStatusCode.OK, _regraAplicacao.ObterTodos(idFilial));
        }
        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorId(int id)
        {
            return CreateResponse(HttpStatusCode.OK, _regraAplicacao.ObterPorId(id));
        }
        [Route("adicionar")]
        [HttpPost]
        public Task<HttpResponseMessage> Adicionar(Regra obj)
        {
            return CreateResponse(HttpStatusCode.OK, _regraAplicacao.Adicionar(obj));
        }
        [Route("obterPorDesconto")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorTipoDesconto(int idFilial, ETipoDesconto tipo)
        {
            return CreateResponse(HttpStatusCode.OK, _regraAplicacao.ObterPorTipoDesconto(idFilial,tipo));
        }
        [Route("obterPorValor")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal)
        {
            return CreateResponse(HttpStatusCode.OK, _regraAplicacao.ObterPorValorInicialFinal(idFilial,valorInicial,valorFinal));
        }
    }
}