using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppFidelidade.Infra.Externo.Servicos
{
    public class PushNotification
    {
        private HttpClient client = new HttpClient();
        public PushNotification()
        {
            client.BaseAddress = new System.Uri("https://fcm.googleapis.com/fcm/");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=AAAAaHqyOAc:APA91bGUUpADwfBV9iAKds1ADdDAv248e-No5Smj2iH8iNStbiiEEibakBYUK8sO8TOCXB8Kd09WMZK3klzBWNlav5BN3ChiDVSu764dfxp0wYMCsAs5nnr4dtbYbT3zhqx2wmXhjSL9");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SendGooglePush(string tokenPush, string titulo, string message)
        {
            if (string.IsNullOrEmpty(tokenPush)) return;
            var push = new
            {
                to = tokenPush,
                data = new
                {
                    title = titulo,
                    message = message,
                    info1 = "info1"
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(push), System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("send", content).Result;
        }
    }
}