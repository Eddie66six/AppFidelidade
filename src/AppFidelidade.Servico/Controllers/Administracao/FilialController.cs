using AppFidelidade.Aplicacao.Aplicacao.Administracao;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
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
        private readonly FilialAplicacao _filialAplicacao;
        public FilialController(FilialAplicacao filialAplicacao):base()
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
    }
}