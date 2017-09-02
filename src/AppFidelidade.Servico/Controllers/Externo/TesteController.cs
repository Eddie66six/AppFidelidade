using AppFidelidade.Infra.Externo.Servicos;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppFidelidade.Servico.Controllers.Externo
{
    [RoutePrefix("api/v1/teste")]
    public class TesteController : BaseController
    {
        [Route("sendGooglePush")]
        [HttpPost]
        public Task<HttpResponseMessage> SendGooglePush()
        {
            var push = new PushNotification();
            push.SendGooglePush("cyoGNgWOh_c:APA91bHEGcp74Uz9TC2jbzJDZKYo9WEGbPegtcuicUbF7Tpi9I6dnWnA1mZLFVoBRZ-F8NFMta0GF8OEY545co0fYcfWzNgL05XuXYLsi1fwD2TNYc94mt2G-qVpbNFUossqS37XToqN", "titulo", "message");
            return CreateResponse(HttpStatusCode.OK, "");
        }
    }
}