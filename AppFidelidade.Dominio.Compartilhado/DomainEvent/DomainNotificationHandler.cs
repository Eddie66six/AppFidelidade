using System;
using System.Collections.Generic;
using System.Linq;

namespace AppFidelidade.Dominio.Compartilhado.DomainEvent
{
    public class DomainNotificationHandler : IDomainHandler<DomainNotification>
    {
        private List<DomainNotification> domainNotifications;
        public DomainNotificationHandler()
        {
            domainNotifications = new List<DomainNotification>();
        }

        public void Dispose()
        {
            domainNotifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification args)
        {
            domainNotifications.Add(args);
        }

        public bool HasNotifications()
        {
            return domainNotifications.Any();
        }

        public IEnumerable<DomainNotification> Notify()
        {
            return domainNotifications;
        }
    }
}