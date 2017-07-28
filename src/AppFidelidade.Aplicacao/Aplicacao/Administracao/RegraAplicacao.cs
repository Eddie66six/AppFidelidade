using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Enum;
using System;
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
            if (funcionario == null)
            {
                DomainEvent.Raise(new DomainNotification("adicionarRegra", "Usuario nao encontrado"));
                return null;
            }
            if (funcionario.Tipo != Dominio.Funcionario.Enum.ETipoFuncionario.Administrador)
            {
                DomainEvent.Raise(new DomainNotification("adicionarRegra", "Funcionario sem autorização"));
                return null;
            }
            var contratoResumo = _contratoRepositorio.ObterResumoRegraFuncionario(funcionario.IdFilial);
            if (contratoResumo == null)
            {
                DomainEvent.Raise(new DomainNotification("adicionarRegra", "Contrato nao encontrado"));
                return null;
            }
            if (contratoResumo.RegrasCadastradas >= contratoResumo.MaxRegrasCadastradas)
            {
                DomainEvent.Raise(new DomainNotification("adicionarRegra", "Quantidade maxima da regra atingido"));
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
    }
}
