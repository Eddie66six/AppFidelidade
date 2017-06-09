using AppFidelidade.Dominio.Cliente.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;

namespace AppFidelidade.Infra.Data.Repositorio.Cliente
{
    public class ClienteRepositorio : BaseRepositorio<Dominio.Cliente.Entidade.Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }
    }
}
