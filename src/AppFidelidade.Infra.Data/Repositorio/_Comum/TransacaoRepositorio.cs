using System;
using AppFidelidade.Dominio._Comum.Interface.Repositorio;

namespace AppFidelidade.Infra.Data.Repositorio._Comum
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        protected readonly Contexto _Db;
        public TransacaoRepositorio(Contexto Db)
        {
            _Db = Db;
        }
        public bool Commit()
        {
            try
            {
                _Db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
