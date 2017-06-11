using System;
using System.Collections.Generic;
using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;
using System.Linq;
using System.Data.Entity;

namespace AppFidelidade.Infra.Data.Repositorio.Administracao
{
    public class EmpresaRepositorio : BaseRepositorio<Empresa>, IEmpresaRepositorio
    {
        public EmpresaRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }

        public Empresa ObterPorId(int id, string[] includes)
        {
            var query = Db.Empresa.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(p => p.IdEmpresa == id && p.DataExclusao == null);
        }

        public List<Empresa> ObterTodos(int idEmpresa, string[] includes)
        {
            var query = Db.Empresa.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(p=>p.DataExclusao == null && p.IdEmpresa == idEmpresa).ToList();
        }
    }
}