namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands
{
    public class UpdateCakeCommand
    {
        /// <summary>
        /// Gets or sets the ID of the cake.
        /// </summary>
        public int CakeId { get; set; }
        
        /// <summary>
        /// Gets or sets the ID of category to which to add the cake.
        /// </summary>
        public int CategoryId { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the cake.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the description of the cake.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the size of the new cake (in cm).
        /// </summary>
        public int Size { get; set; }
        
        /// <summary>
        /// Gets or sets the number of portions to get out of the cake.
        /// </summary>
        public ServingPortions ServingPortions { get; set; }
        
        /// <summary>
        /// Gets or sets the shape of the cake.
        /// </summary>
        public CakeShape Shape { get; set; }
    }
}