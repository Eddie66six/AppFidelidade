using AppFidelidade.Dominio.Funcionario.Interface.Applicacao;
using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;
using AppFidelidade.Dominio.Funcionario.ViewModel;

namespace AppFidelidade.Aplicacao.Aplicacao.Funcionario
{
    public class FuncionarioAplicacao : IFuncionarioAplicacao
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public FuncionarioAplicacao(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public Dominio.Funcionario.Entidade.Funcionario ObterPorId(int idFuncionarioLogado, int idFuncionario)
        {
            string[] includes = { };
            if (_funcionarioRepositorio.ObterPorId(idFuncionarioLogado, includes)?.Tipo != Dominio.Funcionario.Enum.ETipoFuncionario.Administrador)
                return null;
            return _funcionarioRepositorio.ObterPorId(idFuncionario, includes);
        }

        public FuncionarioListaViewModel ObterTodosPorFilial(int idFuncionarioLogado, int idFilial, int take, int skip)
        {
            string[] includes = { };
            if (_funcionarioRepositorio.ObterPorId(idFuncionarioLogado, includes)?.Tipo != Dominio.Funcionario.Enum.ETipoFuncionario.Administrador)
                return null;
            return _funcionarioRepositorio.ObterTodosPorFilial(idFuncionarioLogado, idFilial, take, skip, includes);
        }
        public FuncionarioListaViewModel ObterTodosPorEmpresa(int idFuncionarioLogado, int idEmpresa, int take, int skip)
        {
            string[] includes = { };
            if (_funcionarioRepositorio.ObterPorId(idFuncionarioLogado, includes)?.Tipo != Dominio.Funcionario.Enum.ETipoFuncionario.Administrador)
                return null;
            return _funcionarioRepositorio.ObterTodosPorEmpresa(idEmpresa, take, skip, includes);
        }
    }
}
