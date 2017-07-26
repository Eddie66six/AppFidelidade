using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Administracao
{
    [Authorize]
    [RoutePrefix("api/v1/contrato")]
    public class ContratoController : BaseController
    {
        private readonly IContratoAplicacao _contratoAplicacao;
        public ContratoController(IContratoAplicacao contratoAplicacao)
        {
            _contratoAplicacao = contratoAplicacao;
        }

        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterResumo(int idFuncionarioLogado, int idFilial)
        {
            return CreateResponse(HttpStatusCode.OK, _contratoAplicacao.ObterResumoRegraFuncionario(idFuncionarioLogado, idFilial));
        }
    }
}