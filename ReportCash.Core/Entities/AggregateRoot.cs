using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportCash.Core.Events;

namespace ReportCash.Core.Entities
{
    public class AggregateRoot : IEntityBase
    {
        private List<IDomainEvent> _events = new List<IDomainEvent>();
        public Guid Id { get; protected set; }
        public IEnumerable<IDomainEvent> Events => _events;
        protected void AddEvent(IDomainEvent @event)
        {
            if (_events is null)
            _events = new List<IDomainEvent>();

            _events.Add(@event);
        }
    }
}