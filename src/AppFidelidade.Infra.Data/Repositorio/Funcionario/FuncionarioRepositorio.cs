using AppFidelidade.Dominio.Funcionario.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;

namespace AppFidelidade.Infra.Data.Repositorio.Funcionario
{
    public class FuncionarioRepositorio : BaseRepositorio<Dominio.Funcionario.Entidade.Funcionario>, IFuncionarioRepositorio
    {
        public FuncionarioRepositorio(ContextoManager contextManager) : base(contextManager)
        {
        }
    }
}
