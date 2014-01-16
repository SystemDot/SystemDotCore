using System;
using SystemDot.Domain.Aggregation;

namespace SystemDot.Domain
{
    public interface IDomainRepository
    {
        TAggregateRoot Get<TAggregateRoot>(Guid aggregateRootId) 
            where TAggregateRoot : AggregateRoot, new();

        bool Exists(Guid aggregateRootId);
    }
}