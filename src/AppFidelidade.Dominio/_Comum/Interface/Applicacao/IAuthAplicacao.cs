using AppFidelidade.Dominio._Comum.ViewModel;

namespace AppFidelidade.Dominio._Comum.Interface.Applicacao
{
    public interface IAuthAplicacao
    {
        FuncionarioLoginViewModel funcionario(string usuario, string senha);
    }
}
