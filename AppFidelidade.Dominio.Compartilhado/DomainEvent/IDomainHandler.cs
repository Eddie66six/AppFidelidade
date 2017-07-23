using System;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Compartilhado.DomainEvent
{
    public interface IDomainHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}
