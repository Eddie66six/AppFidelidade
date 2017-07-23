using System;
using System.Collections.Generic;

namespace AppFidelidade.Dominio.Compartilhado.DomainEvent
{
    public interface IContainer
    {
        T GetService<T>();
        object GetService(Type serviceType);
        IEnumerable<T> GetServices<T>();
        IEnumerable<object> GetServices(Type serviceType);
    }
}
