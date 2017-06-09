using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;

namespace AppFidelidade.Infra.Data.Repositorio.Administracao
{
    public class RegraRepositorio : BaseRepositorio<Regra>, IRegraRepositorio
    {
        public RegraRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }
    }
}
