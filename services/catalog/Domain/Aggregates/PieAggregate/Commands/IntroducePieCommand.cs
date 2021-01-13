namespace Backerei.Catalog.Domain.Aggregates.PieAggregate.Commands
{
    /// <summary>
    /// Use this command to introduce a new pie in the bakery.
    /// </summary>
    public class IntroducePieCommand
    {
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