using System;
using System.Collections.Generic;

namespace Backerei.Catalog.Domain.Aggregates.PieAggregate.Commands
{
    /// <summary>
    /// Use this command to update the details of a pie.
    /// </summary>
    public class UpdatePieDetailsCommand
    {
        /// <summary>
        /// Gets or sets the ID of the pie.
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
        
        /// <summary>
        /// Gets or sets the ingredients for the pie.
        /// </summary>
        public IEnumerable<IngredientData> Ingredients { get; set; }
    }
}