using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.ViewModel;

namespace AppFidelidade.Dominio.Administracao.Interface.Repositorio
{
    public interface IContratoRepositorio : IBaseRepositorio<Contrato>
    {
        ResumoRegraFuncionarioViewModel ObterResumoRegraFuncionario(int idFilial);
        Contrato ObterPorIdFilial(int idFilial);
    }
}
