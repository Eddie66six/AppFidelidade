using AppFidelidade.Dominio.Administracao.ViewModel;

namespace AppFidelidade.Dominio.Administracao.Interface.Applicacao
{
    public interface IContratoAplicacao
    {
        ResumoRegraFuncionarioViewModel ObterResumoRegraFuncionario(int idFuncionarioLogado, int idFilial);
    }
}
