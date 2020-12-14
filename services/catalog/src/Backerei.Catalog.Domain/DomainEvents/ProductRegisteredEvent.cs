using System;
using Backerei.Catalog.Domain.Common;

namespace Backerei.Catalog.Domain.DomainEvents
{
    public class ProductRegisteredEvent : DomainEvent
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public double Price { get; init; }
    }
}