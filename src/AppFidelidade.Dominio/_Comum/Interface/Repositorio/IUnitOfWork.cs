using System;

namespace AppFidelidade.Dominio._Comum.Interface.Repositorio
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
