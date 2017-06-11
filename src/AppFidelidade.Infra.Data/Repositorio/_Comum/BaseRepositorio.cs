using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using System;
using System.Data.Entity;
using System.Linq;

namespace AppFidelidade.Infra.Data.Repositorio._Comum
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : class
    {
        protected Contexto Db => _contextManager.GetContext();
        protected readonly ContextoManager _contextManager;
        public BaseRepositorio(ContextoManager contextManager)
        {
            _contextManager = contextManager;
        }
        public T Adicionar(T obj)
        {
            Db.Set<T>().Add(obj);
            return obj;
        }

        public void Atualizar(T obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }

        public void Remover(T obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }
    }
}
