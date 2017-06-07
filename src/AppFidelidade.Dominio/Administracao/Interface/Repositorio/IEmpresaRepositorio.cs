using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Administracao.Entidade;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Interface.Repositorio
{
    public interface IEmpresaRepositorio : IBaseRepositorio<Empresa>
    {
        Empresa ObterPorId(int id, string[] includes);
        List<Empresa> ObterTodos(string[] includes);
        void Remover(int id);
    }
}
