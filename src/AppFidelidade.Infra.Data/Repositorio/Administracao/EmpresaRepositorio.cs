using AppFidelidade.Dominio.Administracao.Entidade;
using AppFidelidade.Dominio.Administracao.Interface.Repositorio;
using AppFidelidade.Infra.Data.Repositorio._Comum;

namespace AppFidelidade.Infra.Data.Repositorio.Administracao
{
    public class EmpresaRepositorio : BaseRepositorio<Empresa>, IEmpresaRepositorio
    {
    }
}
