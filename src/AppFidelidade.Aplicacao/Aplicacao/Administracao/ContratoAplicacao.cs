using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.ViewModel;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;

namespace AppFidelidade.Aplicacao.Aplicacao.Administracao
{
    public class ContratoAplicacao : AppBase, IContratoAplicacao
    {
        private readonly IContratoRepositorio _contratoRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        public ContratoAplicacao(IContratoRepositorio contratoRepositorio, IFuncionarioRepositorio funcionarioRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _contratoRepositorio = contratoRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public ResumoRegraFuncionarioViewModel ObterResumoRegraFuncionario(int idFuncionarioLogado, int idFilial)
        {
            var funcionario = _funcionarioRepositorio.ObterPorId(idFuncionarioLogado, new string[] { });
            if (funcionario == null)
            {
                DomainEvent.Raise(new DomainNotification("Resumo", "Funcionario nao encontrato"));
                return null;
            }
            return _contratoRepositorio.ObterResumoRegraFuncionario(funcionario.IdFilial);
        }
    }
}
