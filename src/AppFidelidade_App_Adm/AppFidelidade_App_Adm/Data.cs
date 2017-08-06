using System;

namespace AppFidelidade_App_Adm
{
    public static class Data
    {
        public static DateTime DataUltimoLogin;
        private static Models.FuncionarioLogin FuncionarioLogin;
        public static void SalvarLogin(Models.FuncionarioLogin funcionarioLogin)
        {
            FuncionarioLogin = funcionarioLogin;
            DataUltimoLogin = DateTime.Now;
        }
        public static bool ExisteFuncionario()
        {
            return FuncionarioLogin != null;
        }
        public static string ObterToken()
        {
            return FuncionarioLogin.LoginData.Token;
        }
        public static int ObterIdFilial()
        {
            return FuncionarioLogin.Funcionario.IdFilial;
        }
        public static int ObterIdFuncionario()
        {
            return FuncionarioLogin.Funcionario.IdFuncionario;
        }

        public static int ObterTipoFuncionario()
        {
            return FuncionarioLogin?.Funcionario?.Tipo ?? 2;
        }
    }
}
