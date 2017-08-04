using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Enum;
using AppFidelidade.Dominio.Administracao.ViewModel;
using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;

namespace AppFidelidade.Aplicacao.Aplicacao.Administracao
{
    public class RegraAplicacao : AppBase, IRegraAplicacao
    {
        private readonly IRegraRepositorio _regraRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IContratoRepositorio _contratoRepositorio;
        public RegraAplicacao(IRegraRepositorio regraRepositorio, IFuncionarioRepositorio funcionarioRepositorio, IContratoRepositorio contratoRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _regraRepositorio = regraRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _contratoRepositorio = contratoRepositorio;
        }

        public RegraBasicoViewModel Adicionar(RegraBasicoViewModel obj)
        {
            var funcionario = _funcionarioRepositorio.ObterPorId(obj.IdFuncionarioLogado, new string[] { });
            if (funcionario == null || funcionario.Tipo != Dominio.Funcionario.Enum.ETipoFuncionario.Administrador)
            {
                DomainEvent.Raise(new DomainNotification("adicionarRegra", funcionario == null ? "Usuario nao encontrado" : "Funcionario sem autorização"));
                return null;
            }
            var contratoResumo = _contratoRepositorio.ObterResumoRegraFuncionario(funcionario.IdFilial);
            if (contratoResumo == null || contratoResumo.RegrasCadastradas >= contratoResumo.MaxRegrasCadastradas)
            {
                DomainEvent.Raise(new DomainNotification("adicionarRegra", contratoResumo == null ? "Contrato nao encontrado" : "Quantidade maxima da regra atingido"));
                return null;
            }

            var objSalvo = _regraRepositorio.Adicionar(new Regra(obj.Nome, obj.TipoDesconto, obj.ValorAcimaDe, obj.ValorDaRegra, funcionario.IdFilial, funcionario.IdFuncionario));
            return Commit() ? new RegraBasicoViewModel(objSalvo) : null;
        }

        public Regra ObterPorId(int id)
        {
            string[] includes = { };
            return _regraRepositorio.ObterPorId(id, includes);
        }

        public RegraListaViewModel ObterPorTipoDesconto(int idFilial, ETipoDesconto tipo, int take, int skip)
        {
            string[] includes = { };
            return _regraRepositorio.ObterPorTipoDesconto(idFilial, tipo, take, skip, includes);
        }

        public RegraListaViewModel ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal, int take, int skip)
        {
            string[] includes = { };
            return _regraRepositorio.ObterPorValorInicialFinal(idFilial, valorInicial, valorFinal, take, skip, includes);
        }

        public RegraListaViewModel ObterTodos(int idFilial, int take, int skip)
        {
            string[] includes = { };
            return _regraRepositorio.ObterTodos(idFilial, take, skip, includes);
        }

        public void AtivarDesativar(int idRegra, int idFuncionarioLogado)
        {
            var funcionario = _funcionarioRepositorio.ObterPorId(idFuncionarioLogado, new string[] { });
            if (funcionario == null || funcionario.Tipo != Dominio.Funcionario.Enum.ETipoFuncionario.Administrador)
            {
                DomainEvent.Raise(new DomainNotification("AtivarDesativar", funcionario == null ? "Usuario nao encontrado" : "Funcionario sem autorização"));
                return;
            }
            var regra = _regraRepositorio.ObterPorId(idRegra, new string[] { });
            if(regra == null)
            {
                DomainEvent.Raise(new DomainNotification("AtivarDesativar", "Regra nao encontrada"));
                return;
            }
            regra.AtivarDesativar();
            Commit();
        }
    }
}
