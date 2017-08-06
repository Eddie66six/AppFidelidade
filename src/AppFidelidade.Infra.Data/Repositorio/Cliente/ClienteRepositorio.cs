using System.Collections.Generic;
using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;
using System.Linq;
using System.Data.Entity;
using System;

namespace AppFidelidade.Infra.Data.Repositorio.Cliente
{
    public class ClienteRepositorio : BaseRepositorio<Dominio.Cliente.Entidade.Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }

        public Dominio.Cliente.Entidade.Cliente ObeterPorTokenId(string tokenId, string[] includes)
        {
            var query = Db.Cliente.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(p=>p.TokenId == tokenId && p.Compras.Any(i=>i.ValorRestanteCredito > 0));
        }

        public List<Dominio.Cliente.Entidade.Cliente> ObterPorFilial(int idFilial, string[] includes)
        {
            var query = Db.Cliente.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(p => p.Filiais.Any(i => i.IdFilial == idFilial)).ToList();
        }

        public Dominio.Cliente.Entidade.Cliente ObterPorId(int id, string[] includes)
        {
            var query = Db.Cliente.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(p => p.IdCliente == id);
        }

        public decimal ObterTotalCreditosCliente(int idCliente)
        {
            return Db.Compra.Where(p => p.IdCliente == idCliente && p.DataRetiradaCredito.HasValue && p.ValorRestanteCredito > 0 && DbFunctions.TruncateTime(p.DataVencimentoCredito) > DbFunctions.TruncateTime(DateTime.Today)).Sum(p=>p.ValorRestanteCredito);
        }

        public bool VerificaSeTokenIdJaExiste(string tokenId)
        {
            return Db.Cliente.Any(p => p.TokenId == tokenId);
        }
    }
}
