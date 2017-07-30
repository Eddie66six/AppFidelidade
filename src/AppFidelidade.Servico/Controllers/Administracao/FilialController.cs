using AppFidelidade.Aplicacao.Aplicacao.Administracao;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.ViewModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Administracao
{
    [Authorize]
    [RoutePrefix("api/v1/filial")]
    public class FilialController : BaseController
    {
        private readonly IFilialAplicacao _filialAplicacao;
        public FilialController(IFilialAplicacao filialAplicacao) : base()
        {
            _filialAplicacao = filialAplicacao;
        }

        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterTodos(int idEmpresa)
        {
            return CreateResponse(HttpStatusCode.OK, _filialAplicacao.ObterTodos());
        }
        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorId(int id)
        {
            return CreateResponse(HttpStatusCode.OK, _filialAplicacao.ObterPorId(id));
        }

        [Route("deletar")]
        [HttpDelete]
        public Task<HttpResponseMessage> Delete(int id)
        {
            _filialAplicacao.Remover(id);
            return CreateResponse(HttpStatusCode.OK, "");
        }
        [Route("adicionar")]
        [HttpPost]
        public Task<HttpResponseMessage> Adicionar(Filial obj)
        {
            return CreateResponse(HttpStatusCode.OK, _filialAplicacao.Adicionar(obj));
        }
        [Route("atualizar")]
        [HttpPut]
        public Task<HttpResponseMessage> Atualizar(Filial obj)
        {
            _filialAplicacao.Atualizar(obj);
            return CreateResponse(HttpStatusCode.OK, "");
        }
        [Route("obterResumo")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterResumo(int idFilial)
        {
            return CreateResponse(HttpStatusCode.OK, _filialAplicacao.ObterResumoPorId(idFilial));
        }
        [Route("lancarCompra")]
        [HttpPost]
        public Task<HttpResponseMessage> LancarCompra(LancarCompraViewModel obj)
        {
            return CreateResponse(HttpStatusCode.OK, _filialAplicacao.LancarCompra(obj));
        }
        [Route("resgatarCredito")]
        [HttpPost]
        public Task<HttpResponseMessage> ResgatarCredito(ResgatarCreditoViewModel obj)
        {
            _filialAplicacao.ResgatarCredito(obj);
            return CreateResponse(HttpStatusCode.OK, "");
        }
        [Route("obterMaximoCreditoPermitidoParaUso")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterMaximoCreditoPermitidoParaUso(int idFilial)
        {
            return CreateResponse(HttpStatusCode.OK, _filialAplicacao.ObterMaximoCreditoPermitidoParaUso(idFilial));
        }

        [Route("obterInformacoesBasicasFilial")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterInformacoesBasicasFilial(int idFilial, int idFuncionarioLogado)
        {
            return CreateResponse(HttpStatusCode.OK, _filialAplicacao.ObterInformacoesBasicasFilial(idFilial, idFuncionarioLogado));
        }
    }
}