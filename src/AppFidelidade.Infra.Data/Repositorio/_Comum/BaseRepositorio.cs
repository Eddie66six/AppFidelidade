using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using System;
using System.Data.Entity;
using System.Linq;

namespace AppFidelidade.Infra.Data.Repositorio._Comum
{
    public class BaseRepositorio<T> : IDisposable, IBaseRepositorio<T> where T : class
    {
        protected readonly Contexto Db = new Contexto();
        public T Adicionar(T obj)
        {
            Db.Set<T>().Add(obj);
            return obj;
        }

        public void Atualizar(T obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //public void Remover(int id)
        //{
        //    var obj = ObterPorId(id);
        //    Db.Set<T>().Remove(obj);
        //    Db.SaveChanges();
        //}
    }
}
