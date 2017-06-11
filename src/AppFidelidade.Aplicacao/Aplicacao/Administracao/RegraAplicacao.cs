using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Applicacao;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using System.Collections.Generic;
using AppFidelidade.Dominio.Administracao.Enum;
using System;

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

        public List<Regra> ObterPorTipoDesconto(int idFilial, ETipoDesconto tipo)
        {
            string[] includes = { };
            return _regraRepositorio.ObterPorTipoDesconto(idFilial, tipo, includes);
        }

        public List<Regra> ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal)
        {
            string[] includes = { };
            return _regraRepositorio.ObterPorValorInicialFinal(idFilial, valorInicial, valorFinal, includes);
        }

        public List<Regra> ObterTodos(int idFilial)
        {
            string[] includes = { };
            return _regraRepositorio.ObterTodos(idFilial, includes);
        }
    }
}
