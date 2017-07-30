using System.Collections.Generic;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;
using System.Linq;
using System.Data.Entity;

namespace AppFidelidade.Infra.Data.Repositorio.Administracao
{
    public class FilialRepositorio : BaseRepositorio<Filial>, IFilialRepositorio
    {
        public FilialRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }

        public Filial ObterPorId(int id, string[] includes)
        {
            var query = Db.Filial.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(p => p.IdEmpresa == id && p.DataExclusao == null && p.Contratos.Any(i=> i.DataCancelamento == null));
        }

        public Contrato ObterContratoPorIdFilial(int id, string[] includes)
        {
            var query = Db.Contrato.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(p => p.Filial.IdFilial == id && p.DataCancelamento == null);
        }

        public List<Filial> ObterTodos(string[] includes)
        {
            var query = Db.Filial.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(p => p.DataExclusao == null).ToList();
        }

        public int ObterQuantidadeFuncionariosCadastrados(int idFilial)
        {
            return Db.Funcionario.Count(p => p.IdFilial == idFilial);
        }
    }
}
