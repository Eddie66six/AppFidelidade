using System.Collections.Generic;

namespace AppFidelidade.Dominio._Comum.Interface.Repositorio
{
    public interface IBaseRepositorio<T> where T : class
    {
        T Adicionar(T obj);
        T ObterPorId(int id);
        IEnumerable<T> ObterTodos();
        void Atualizar(T obj);
        void Remover(int id);
        void Dispose();
    }
}