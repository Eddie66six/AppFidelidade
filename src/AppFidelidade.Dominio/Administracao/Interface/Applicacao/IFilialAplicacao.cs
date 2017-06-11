using System.Collections.Generic;

namespace AppFidelidade.Dominio.Administracao.Interface.Applicacao
{
    public interface IFilialAplicacao
    {
        IEnumerable<Entidade.Filial> ObterTodos();
        Entidade.Filial ObterPorId(int id);
        Entidade.Filial Adicionar(Entidade.Filial obj);
        void Atualizar(Entidade.Filial obj);
        void Remover(int id);
    }
}
