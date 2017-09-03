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

        [Route("compartilharFacebook")]
        [HttpPost]
        public Task<HttpResponseMessage> CompartilharFacebook()
        {
            var facebookApi = new Facebook("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdGFibGVfc2lkIjoic2lkOmYzYmMzZTcwMWFkNDUxYWU4NTg1YTcyMDVjNTJkZjQ1Iiwic3ViIjoic2lkOjk2NWU4YTRkZDQ0NDBjNzliZmE3YmY0ZmZjOWM0YjhjIiwiaWRwIjoiZmFjZWJvb2siLCJ2ZXIiOiIzIiwiaXNzIjoiaHR0cHM6Ly9nMnhhcHBmaWRlbGlkYWRlLmF6dXJld2Vic2l0ZXMubmV0LyIsImF1ZCI6Imh0dHBzOi8vZzJ4YXBwZmlkZWxpZGFkZS5henVyZXdlYnNpdGVzLm5ldC8iLCJleHAiOjE1MDk1Nzg0OTUsIm5iZiI6MTUwNDQxMDY4N30.jMLW-QLT-lN5xuSObALjYpCQlDmkQrUSYLl4k_AiRFQ");
            facebookApi.Compartilhar("Reward teste", "https://www.facebook.com/g2xsoftware/");
            return CreateResponse(HttpStatusCode.OK, "");
        }
    }
}