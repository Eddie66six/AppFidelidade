using System;

namespace AppFidelidade.Dominio.Compartilhado.DomainEvent
{
    public class DomainNotification : IDomainEvent
    {
        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            Date = DateTime.UtcNow;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
        public DateTime Date { get; }
    }
}
