using System;

namespace AppFidelidade_App_Adm.Models
{
    public class FuncionarioLogin
    {
        public Funcionario Funcionario { get; set; }
        public LoginData LoginData { get; set; }
    }

    public class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public int IdFilial { get; set; }
    }
    public class LoginData
    {
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
