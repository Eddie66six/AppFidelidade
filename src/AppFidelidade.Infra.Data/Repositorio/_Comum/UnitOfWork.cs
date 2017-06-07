using System;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;

namespace AppFidelidade.Infra.Data.Repositorio._Comum
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private Contexto _db;
        public UnitOfWork(Contexto db)
        {
            _db = db;
        }
        public bool Commit()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
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
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }
    }
}
