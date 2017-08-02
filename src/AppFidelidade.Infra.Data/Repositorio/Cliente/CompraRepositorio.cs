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
                    Creditos = p.valorCredito ?? 0
                }).ToList()
            };
        }
        public ClienteCreditoViewModel ObeterBasicoCreditosCliente(int idCliente)
        {
            var compras = Db.Compra.Include("Filial")
                .Where(p => p.IdCliente == idCliente && ((p.DataRetiradaCredito.HasValue && p.ValorRestanteCredito > 0) || p.DataRetiradaCredito == null)).ToList();
            return new ClienteCreditoViewModel
            {
                TotalCreditosParaRetirada = compras.Where(i => i.DataVencimentoCredito == null && i.DataRetiradaCredito == null).Sum(i => i.valorCredito ?? 0),
                Creditos = compras.Where(p => p.DataRetiradaCredito.HasValue).GroupBy(p => new { p.Filial, p.DataVencimentoCredito }).Select(p => new ClienteCreditoBasicoViewModel
                {
                    IdFilial = p.Key.Filial.IdFilial,
                    NomeFilial = p.Key.Filial.NomeFantasia,
                    DataVencimento = p.Key.DataVencimentoCredito,
                    TotalCreditos = compras.Where(i => i.DataVencimentoCredito == p.Key.DataVencimentoCredito && i.DataRetiradaCredito.HasValue && i.ValorRestanteCredito > 0).Sum(i => i.ValorRestanteCredito),
                }).ToList()
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
