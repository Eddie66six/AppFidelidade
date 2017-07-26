using AppFidelidade.Dominio.Administracao.ViewModel;

namespace AppFidelidade.Dominio.Administracao.Interface.Repositorio
{
    public interface IContratoRepositorio
    {
        ResumoRegraFuncionarioViewModel ObterResumoRegraFuncionario(int idFilial);
    }
}
