using System;
using Backerei.Catalog.Domain.Common;

namespace Backerei.Catalog.Domain.Aggregates.PieAggregate.Events
{
    /// <summary>
    /// Gets raised when the details of a pie have been updated.
    /// </summary>
    public class PieDetailsUpdatedEvent: DomainEvent
    {
        /// <summary>
        /// Gets or sets the ID of the pie that was updated.
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