using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Administracao
{
    [Authorize]
    [RoutePrefix("api/v1/empresa")]
    public class EmpresaController : BaseController
    {
        private readonly IEmpresaAplicacao _empresaAplicacao;
        public EmpresaController(IEmpresaAplicacao empresaAplicacao):base()
        {
            _empresaAplicacao = empresaAplicacao;
        }

        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterTodos(int idEmpresa)
        {
            return CreateResponse(HttpStatusCode.OK, _empresaAplicacao.ObterTodos(idEmpresa));
        }
        [Route("obter")]
        [HttpGet]
        public Task<HttpResponseMessage> ObterPorId(int id)
        {
            return CreateResponse(HttpStatusCode.OK, _empresaAplicacao.ObterPorId(id));
        }

        [Route("deletar")]
        [HttpDelete]
        public Task<HttpResponseMessage> Delete(int id)
        {
            _empresaAplicacao.Remover(id);
            return CreateResponse(HttpStatusCode.OK, "");
        }
        [Route("adicionar")]
        [HttpPost]
        public Task<HttpResponseMessage> Adicionar(Empresa obj)
        {
            return CreateResponse(HttpStatusCode.OK, _empresaAplicacao.Adicionar(obj));
        }
        [Route("atualizar")]
        [HttpPut]
        public Task<HttpResponseMessage> Atualizar(Empresa obj)
        {
            _empresaAplicacao.Atualizar(obj);
            return CreateResponse(HttpStatusCode.OK, "");
        }
    }
}