using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Interface.Applicacao
{
    public interface IEmpresaAplicacao
    {
        IEnumerable<Entidade.Empresa> ObterTodos(int idEmpresa);
        Entidade.Empresa ObterPorId(int id);
        Entidade.Empresa Adicionar(Entidade.Empresa obj);
        void Atualizar(Entidade.Empresa obj);
        void Remover(int id);
    }
}
