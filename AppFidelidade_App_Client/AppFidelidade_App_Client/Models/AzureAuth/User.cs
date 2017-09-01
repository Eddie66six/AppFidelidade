using Newtonsoft.Json;

namespace AppFidelidade_App_Client.Models.AzureAuth
{
    public class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
