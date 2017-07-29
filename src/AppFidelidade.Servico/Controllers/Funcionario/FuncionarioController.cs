using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using AppFidelidade.Dominio.Funcionario.Interface.Applicacao;
using AppFidelidade.Dominio.Funcionario.ViewModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Funcionario
{
    [Authorize]
    [RoutePrefix("api/v1/funcionario")]
    public class FuncionarioController : BaseController
    {
        private readonly IFuncionarioAplicacao _funcionarioAplicacao;
        public FuncionarioController(IFuncionarioAplicacao funcionarioAplicacao):base()
        {
            _funcionarioAplicacao = funcionarioAplicacao;
        }
        [HttpGet]
        [Route("obter/filial")]
        public Task<HttpResponseMessage> ObterTodosFuncionarioFilial(int idFuncionarioLogado, int idFilial, int take, int skip)
        {
            return CreateResponse(HttpStatusCode.OK, _funcionarioAplicacao.ObterTodosPorFilial(idFuncionarioLogado, idFilial, take, skip));
        }
        [HttpGet]
        [Route("obter/empresa")]
        public Task<HttpResponseMessage> ObterTodosFuncionarioEmpresa(int idFuncionarioLogado, int idEmpresa, int take, int skip)
        {
            return CreateResponse(HttpStatusCode.OK, _funcionarioAplicacao.ObterTodosPorEmpresa(idFuncionarioLogado, idEmpresa, take, skip));
        }
        [HttpGet]
        [Route("obter")]
        public Task<HttpResponseMessage> ObterFuncionario(int idFuncionarioLogado, int idFuncionario)
        {
            return CreateResponse(HttpStatusCode.OK, _funcionarioAplicacao.ObterPorId(idFuncionarioLogado, idFuncionarioLogado));
        }
        [HttpPost]
        [Route("adicionar")]
        public Task<HttpResponseMessage> AdicionarFuncionario(FuncionarioBasicoViewModel obj)
        {
            return CreateResponse(HttpStatusCode.OK, _funcionarioAplicacao.Adicionar(obj));
        }
    }
}