using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;

namespace AppFidelidade.Infra.Data.Repositorio.Cliente
{
    public class CompraRepositorio : BaseRepositorio<Dominio.Cliente.Entidade.Compra>, ICompraRepositorio
    {
        public CompraRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }
    }
}
