using System.Collections.Generic;
using AppFidelidade.Dominio.Cliente.Entidade;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;
using System.Linq;
using System.Data.Entity;

namespace AppFidelidade.Infra.Data.Repositorio.Cliente
{
    public class CompraRepositorio : BaseRepositorio<Compra>, ICompraRepositorio
    {
        public CompraRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }

        public List<Compra> ObterComCreditoPorCliente(int idCliente, string[] includes)
        {
            var query = Db.Compra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(p => p.IdCliente == idCliente && p.DataRetiradaCredito == null).ToList();
        }

        public List<Compra> ObterPorCliente(int idCliente, string[] includes)
        {
            var query = Db.Compra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(p => p.IdCliente == idCliente).ToList();
        }

        public List<Compra> ObterPorFilial(int idFilial, string[] includes)
        {
            var query = Db.Compra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(p => p.IdFilial == idFilial).ToList();
        }

        public Compra ObterPorId(int id, string[] includes)
        {
            var query = Db.Compra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(p => p.IdCompra == id);
        }

        public List<Compra> ObterSemCreditoPorCliente(int idCliente, string[] includes)
        {
            var query = Db.Compra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(p => p.IdCliente == idCliente && p.DataRetiradaCredito != null).ToList();
        }
    }
}
