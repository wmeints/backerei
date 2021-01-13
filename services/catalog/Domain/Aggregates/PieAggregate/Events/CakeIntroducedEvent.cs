using System;
using Backerei.Catalog.Domain.Common;

namespace Backerei.Catalog.Domain.Aggregates.PieAggregate.Events
{
    /// <summary>
    /// Gets raised when a new pie was introduced in the bakery.
    /// </summary>
    public class CakeIntroducedEvent : DomainEvent
    {
        /// <summary>
        /// Gets or sets the pie ID.
        /// </summary>
        public Guid PieId { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the pie.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the description of the pie.
        /// </summary>
        public string Description { get; set; }
    }
}