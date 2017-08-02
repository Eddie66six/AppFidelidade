using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Enum;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;
using System.Linq;
using System.Data.Entity;
using AppFidelidade.Dominio.Administracao.ViewModel;

namespace AppFidelidade.Infra.Data.Repositorio.Administracao
{
    public class RegraRepositorio : BaseRepositorio<Regra>, IRegraRepositorio
    {
        public RegraRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }

        public RegraListaViewModel ObterTodos(int idFilial, int take, int skip, string[] includes)
        {
            var query = Db.Regra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            query = query.Where(p => p.IdFilial == idFilial);
            return new RegraListaViewModel { Total = query.Count(), Regras = query.Select(p=> new RegraBasicoViewModel
            {
                IdRegra = p.IdRegra,
                Nome = p.Nome,
                TipoDesconto = p.TipoDesconto,
                ValorDaRegra = p.ValorDaRegra,
                ValorAcimaDe = p.ValorAcimaDe,
                Inativo = p.Inativo
            }).OrderBy(p=>p.Nome).Skip(skip).Take(take).ToList() };
        }

        public Regra ObterPorId(int id, string[] includes)
        {
            var query = Db.Regra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(p => p.IdFilial == id);
        }

        public RegraListaViewModel ObterPorTipoDesconto(int idFilial, ETipoDesconto tipo, int take, int skip, string[] includes)
        {
            var query = Db.Regra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            query = query.Where(p => p.TipoDesconto == tipo && p.IdFilial == idFilial);
            return new RegraListaViewModel
            {
                Total = query.Count(),
                Regras = query.Select(p => new RegraBasicoViewModel
                {
                    IdRegra = p.IdRegra,
                    Nome = p.Nome,
                    TipoDesconto = p.TipoDesconto,
                    ValorDaRegra = p.ValorDaRegra,
                    ValorAcimaDe = p.ValorAcimaDe,
                    Inativo = p.Inativo
                }).OrderBy(p => p.Nome).Skip(skip).Take(take).ToList()
            };
        }

        public RegraListaViewModel ObterPorValorInicialFinal(int idFilial, decimal valorInicial, decimal valorFinal, int take, int skip, string[] includes)
        {
            var query = Db.Regra.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            query = query.Where(p => p.ValorAcimaDe == 0 && p.IdFilial == idFilial);
            return new RegraListaViewModel
            {
                Total = query.Count(),
                Regras = query.Select(p => new RegraBasicoViewModel
                {
                    IdRegra = p.IdRegra,
                    Nome = p.Nome,
                    TipoDesconto = p.TipoDesconto,
                    ValorDaRegra = p.ValorDaRegra,
                    ValorAcimaDe = p.ValorAcimaDe,
                    Inativo = p.Inativo
                }).OrderBy(p => p.Nome).Skip(skip).Take(take).ToList()
            };
        }

        public int ObterQuantidadeRegrasAtivasCadastradas(int idFilial)
        {
            return Db.Regra.Count(p => p.IdFilial == idFilial);
        }
    }
}
