using System;
using System.Collections.Generic;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Enum;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;
using System.Linq;
using System.Data.Entity;

namespace AppFidelidade.Infra.Data.Repositorio.Administracao
{
    public class RegraRepositorio : BaseRepositorio<Regra>, IRegraRepositorio
    {
        public RegraRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }

        public List<Regra> ObterTodos(int idFilial, string[] includes)
        {
            var query = Db.Regra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(p => p.IdFilial == idFilial && p.DataExclusao == null).ToList();
        }

        public Regra ObterPorId(int id, string[] includes)
        {
            var query = Db.Regra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(p => p.DataExclusao == null && p.IdFilial == id);
        }

        public List<Regra> ObterPorTipoDesconto(int idFilial, ETipoDesconto tipo, string[] includes)
        {
            var query = Db.Regra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(p => p.TipoDesconto == tipo && p.DataExclusao == null && p.IdFilial == idFilial).ToList();
        }

        public List<Regra> ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal, string[] includes)
        {
            var query = Db.Regra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(p => p.DataExclusao == null && p.ValorInicial <= valorInicial && p.ValorFinal >=valorFinal && p.IdFilial == idFilial).ToList();
        }
    }
}
