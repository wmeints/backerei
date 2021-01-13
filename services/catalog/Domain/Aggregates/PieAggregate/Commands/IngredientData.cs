namespace Backerei.Catalog.Domain.Aggregates.PieAggregate.Commands
{
    /// <summary>
    /// Ingredient data to update.
    /// </summary>
    public class IngredientData
    {
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets whether the ingredient is considered an allergen.
        /// </summary>
        public bool IsAllergen { get; set; }
        
        /// <summary>
        /// Gets the relative amount of the ingredient in the pie.
        /// </summary>
        public double RelativeAmount { get; set; }
    }
}