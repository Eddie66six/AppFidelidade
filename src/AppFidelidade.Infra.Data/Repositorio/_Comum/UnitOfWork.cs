using System;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;
using AppFidelidade.Dominio.Compartilhado.DomainEvent;

namespace AppFidelidade.Infra.Data.Repositorio._Comum
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ContextoManager _contextoManager;
        private Contexto contexto => _contextoManager.GetContext();
        public UnitOfWork(ContextoManager contextoManager)
        {
            _contextoManager = contextoManager;
        }
        public bool Commit()
        {
            try
            {
                contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                DomainEvent.Raise(new DomainNotification("SaveChanges", e.Message));
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    if (contexto != null)
            //    {
            //        contexto.Dispose();
            //        contexto = null;
            //    }
            //}
        }
    }
}
