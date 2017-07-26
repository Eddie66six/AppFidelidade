using AppFidelidade.Dominio._Comum.Interface.Applicacao;
using AppFidelidade.Dominio._Comum.ViewModel;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;
using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;

namespace AppFidelidade.Aplicacao.Aplicacao._Comum
{
    public class AuthAplicacao : IAuthAplicacao
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public AuthAplicacao(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        public FuncionarioLoginViewModel funcionario(string usuario, string senha)
        {
            string[] includes = { };
            var funcionario = _funcionarioRepositorio.ObterPorLogin(usuario, senha, includes);
            if (funcionario == null)
            {
                DomainEvent.Raise(new DomainNotification("LoginFuncionario", "Usuario nao encontrado"));
                return null;
            }
            return new FuncionarioLoginViewModel
            {
                IdFuncionario = funcionario.IdFuncionario,
                Nome = funcionario.Nome,
                Tipo = funcionario.Tipo,
                IdFilial = funcionario.IdFilial
            };
        }
    }
}
