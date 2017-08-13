using System.Collections.Generic;
using AppFidelidade.Dominio.Cliente.Entidade;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;
using System.Linq;
using System.Data.Entity;
using AppFidelidade.Dominio.Cliente.ViewModel;
using System;

namespace AppFidelidade.Infra.Data.Repositorio.Cliente
{
    public class CompraRepositorio : BaseRepositorio<Compra>, ICompraRepositorio
    {
        public CompraRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }

        public ClienteCreditosRetirarViewModel ObterBasicoCreditoRetirarCliente(int idCliente)
        {
            var compras = Db.Compra.Include("Filial")
                .Where(p => p.IdCliente == idCliente && p.DataRetiradaCredito == null).ToList();
            return new ClienteCreditosRetirarViewModel
            {
                TotalCreditos = compras.Sum(i => i.valorCredito ?? 0),
                Creditos = compras.Select(p => new ClienteCreditosRetirarBasicoViewModel
                {
                    IdFilial = p.Filial.IdFilial,
                    NomeFilial = p.Filial.NomeFantasia,
                    IdCompra = p.IdCompra,
                    DataCompra = p.Data,
                    Creditos = p.valorCredito ?? 0,
                    ValorCompra = p.ValorCompra
                }).ToList()
            };
        }
        public ClienteCreditoViewModel ObeterBasicoCreditosCliente(int idCliente, int skip, int take)
        {
            Db.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            var compras = Db.Compra.Include("Filial")
                .Where(p => p.IdCliente == idCliente &&
                    (p.DataVencimentoCredito == null || DbFunctions.TruncateTime(p.DataVencimentoCredito) > DbFunctions.TruncateTime(DateTime.Today)) &&
                    ((p.DataRetiradaCredito.HasValue && p.ValorRestanteCredito > 0) || p.DataRetiradaCredito == null)).AsNoTracking().ToList();
            return new ClienteCreditoViewModel
            {
                TotalCreditosParaRetirada = compras.Where(i => i.DataVencimentoCredito == null && i.DataRetiradaCredito == null).Sum(i => i.valorCredito ?? 0),
                TotalRegistros = compras.Where(p => p.DataRetiradaCredito.HasValue).GroupBy(p => new { p.IdFilial,p.Filial.NomeFantasia, p.DataVencimentoCredito }).Count(),
                Creditos = compras.Where(p => p.DataRetiradaCredito.HasValue).GroupBy(p => new { p.IdFilial, p.Filial.NomeFantasia, p.DataVencimentoCredito })
                .Select(p => new ClienteCreditoBasicoViewModel
                {
                    IdFilial = p.Key.IdFilial,
                    NomeFilial = p.Key.NomeFantasia,
                    DataVencimento = p.Key.DataVencimentoCredito,
                    TotalCreditos = p.Sum(i=>i.ValorRestanteCredito),
                    TotalCompras = p.Sum(i=> i.ValorCompra)
                }).OrderBy(p=>p.DataVencimento).Skip(skip).Take(take).ToList()
            };
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

        public Compra ObterPorId(long id, string[] includes)
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
