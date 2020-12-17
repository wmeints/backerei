using System;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate
{
    /// <summary>
    /// Gets thrown when an ingredient can't be found.
    /// </summary>
    public class IngredientNotFoundException : Exception
    {
        /// <summary>
        /// Gets the ID of the ingredient that wasn't found.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="IngredientNotFoundException"/>
        /// </summary>
        /// <param name="id"></param>
        public IngredientNotFoundException(int id) :base($"Ingredient with ID {id} was not found.")
        {
            Id = id;
        }
    }
}