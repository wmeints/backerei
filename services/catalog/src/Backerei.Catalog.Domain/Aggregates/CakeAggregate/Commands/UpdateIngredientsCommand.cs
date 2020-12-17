using System.Collections.Generic;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate;

namespace Backerei.Catalog.Domain.Commands
{
    public class UpdateIngredientsCommand
    {
        public int CakeId { get; set; }
        public IEnumerable<IngredientDTO> Ingredients { get; set; }
    }
}