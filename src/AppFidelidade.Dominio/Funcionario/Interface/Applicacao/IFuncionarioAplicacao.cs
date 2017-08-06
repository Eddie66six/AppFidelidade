using AppFidelidade.Dominio.Funcionario.ViewModel;

namespace AppFidelidade.Dominio.Funcionario.Interface.Applicacao
{
    public interface IFuncionarioAplicacao
    {
        FuncionarioListaViewModel ObterTodosPorFilial(int idFuncionarioLogado, int idFilial, int take, int skip);
        FuncionarioListaViewModel ObterTodosPorEmpresa(int idFuncionarioLogado, int idEmpresa, int take, int skip);
        Entidade.Funcionario ObterPorId(int idFuncionarioLogado,int idFuncionario);
        FuncionarioBasicoViewModel Adicionar(FuncionarioBasicoViewModel obj);
        FuncionarioBasicoViewModel Atualizar(FuncionarioBasicoViewModel obj);
        void Excluir(int idFuncionario, int idFuncionarioLogado);
    }
}
