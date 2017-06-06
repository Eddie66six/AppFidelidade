using AppFidelidade.Dominio.Funcionario.Interface.Applicacao;
using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao.Funcionario
{
    public class FuncionarioAplicacao : IFuncionarioAplicacao
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public FuncionarioAplicacao(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
    }
}
