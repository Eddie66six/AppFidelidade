using System.Collections.Generic;

namespace AppFidelidade.Dominio.Compartilhado.DomainEvent
{
    public static class DomainEvent
    {
        public static DomainNotificationHandler _domainNotificationHandler { get; set; }

        public static void Raise(DomainNotification args)
        {
            if (_domainNotificationHandler == null)
                _domainNotificationHandler = new DomainNotificationHandler();

            _domainNotificationHandler.Handle(args);
        }

    }
}
