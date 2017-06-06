using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers
{
    public class BaseController : ApiController
    {
        protected Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            return Task.FromResult(Request.CreateResponse(code, result));
        }
    }
}