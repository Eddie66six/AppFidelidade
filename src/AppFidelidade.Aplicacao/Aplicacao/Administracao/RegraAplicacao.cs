using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Enum;
using System;
using AppFidelidade.Dominio.Administracao.ViewModel;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;

namespace AppFidelidade.Aplicacao.Aplicacao.Administracao
{
    public class RegraAplicacao : AppBase, IRegraAplicacao
    {
        private readonly IRegraRepositorio _regraRepositorio;
        public RegraAplicacao(IRegraRepositorio regraRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _regraRepositorio = regraRepositorio;
        }

        public Regra Adicionar(Regra obj)
        {
            _regraRepositorio.Adicionar(obj);
            return Commit() ? obj : null;
        }

        public Regra ObterPorId(int id)
        {
            string[] includes = { };
            return _regraRepositorio.ObterPorId(id, includes);
        }

        public RegraListaViewModel ObterPorTipoDesconto(int idFilial, ETipoDesconto tipo, int take, int skip)
        {
            string[] includes = { };
            return _regraRepositorio.ObterPorTipoDesconto(idFilial, tipo,take,skip, includes);
        }

        public RegraListaViewModel ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal, int take, int skip)
        {
            string[] includes = { };
            return _regraRepositorio.ObterPorValorInicialFinal(idFilial, valorInicial, valorFinal,take,skip, includes);
        }

        public RegraListaViewModel ObterTodos(int idFilial, int take, int skip)
        {
            string[] includes = { };
            return _regraRepositorio.ObterTodos(idFilial,take,skip, includes);
        }
    }
}
