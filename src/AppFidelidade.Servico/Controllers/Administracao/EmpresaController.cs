using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Administracao
{
    [RoutePrefix("api/v1/empresa")]
    public class EmpresaController : BaseController
    {
        private readonly IEmpresaAplicacao _empresaAplicacao;
        public EmpresaController(IEmpresaAplicacao empresaAplicacao)
        {
            _empresaAplicacao = empresaAplicacao;
        }

        [Route("get")]
        [HttpGet]
        public Task<HttpResponseMessage> Get()
        {
            return CreateResponse(HttpStatusCode.OK, _empresaAplicacao.ObterTodos());
        }
        [Route("get/{id}")]
        [HttpGet]
        public Task<HttpResponseMessage> Get(int id)
        {
            return CreateResponse(HttpStatusCode.OK, _empresaAplicacao.ObterPorId(id));
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public Task<HttpResponseMessage> Delete(int id)
        {
            _empresaAplicacao.Remover(id);
            return CreateResponse(HttpStatusCode.OK, "");
        }
        [Route("post")]
        [HttpPost]
        public Task<HttpResponseMessage> Adicionar(Empresa obj)
        {
            return CreateResponse(HttpStatusCode.OK, _empresaAplicacao.Adicionar(obj));
        }
        [Route("put/{id}")]
        [HttpPut]
        public Task<HttpResponseMessage> Atualizar(Empresa obj)
        {
            _empresaAplicacao.Atualizar(obj);
            return CreateResponse(HttpStatusCode.OK, "");
        }
    }
}