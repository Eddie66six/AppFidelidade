using Newtonsoft.Json;
using SQLite;

namespace AppFidelidade_App_Adm.Models
{
    [Table("Login")]
    public class SqLiteLogin
    {
        public string Login { get; set; }
        public string LoginData { get; set; }
        public SqLiteLogin()
        {

        }
        public SqLiteLogin(Models.Login login, Models.FuncionarioLogin loginData)
        {
            Login = JsonConvert.SerializeObject(login);
            LoginData = JsonConvert.SerializeObject(loginData);
        }
    }
}
