namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate
{
    /// <summary>
    /// This data transfer object can be used to send/receive information about ingredients.
    /// </summary>
    public class IngredientDTO
    {
        /// <summary>
        /// Gets or sets the name of the ingredient.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the relative weight of the ingredient in the cake.
        /// </summary>
        public int Weight { get; set; }
        
        /// <summary>
        /// Gets or sets whether the ingredient is considered an allergen.
        /// </summary>
        public bool IsAllergen { get; set; }
    }
}