using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Administracao
{
    [RoutePrefix("api/v1/empresa")]
    public class EmpresaController : BaseController
    {
        [Route("get")]
        [HttpGet]
        public Task<HttpResponseMessage> Get()
        {
            return CreateResponse(HttpStatusCode.OK, new { a = "sdf", b = "n" });
        }
    }
}