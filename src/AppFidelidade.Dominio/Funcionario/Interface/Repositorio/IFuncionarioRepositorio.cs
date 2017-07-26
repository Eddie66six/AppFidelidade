using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Funcionario.ViewModel;

namespace AppFidelidade.Dominio.Funcionario.Interface.Repositorio
{
    public interface IFuncionarioRepositorio : IBaseRepositorio<Entidade.Funcionario>
    {
        FuncionarioListaViewModel ObterTodosPorFilial(int idFuncionarioLogado, int idFilial, int take, int skip, string[] includes);
        FuncionarioListaViewModel ObterTodosPorEmpresa(int idFilial, int take, int skip, string[] includes);
        Entidade.Funcionario ObterPorId(int idFuncionario, string[] includes);
        Entidade.Funcionario ObterPorLogin(string usuario, string senha, string[] includes);
        int ObterQuantidadeFuncionarioAtivosCadastrados(int idFilial);
    }
}
