using System;

namespace Backerei.Catalog.Domain.Aggregates.ProductInformation
{
    /// <summary>
    /// Cakes and pies can contain allergens that people will want to know about.
    /// The catalog gives people the insight to make an informed choice.
    /// </summary>
    public class Allergen
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Allergen"/>
        /// </summary>
        private Allergen()
        {
            
        }
        
        /// <summary>
        /// Initializes a new instance of <see cref="Allergen"/>
        /// </summary>
        /// <param name="id">ID of the allergen.</param>
        public Allergen(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        
        /// <summary>
        /// Gets the ID of the allergen
        /// </summary>
        public Guid Id { get; private set; }
        
        /// <summary>
        /// Gets the name of the allergen
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Updates the name of the allergen.
        /// </summary>
        /// <param name="name">Name of the allergen.</param>
        public void UpdateInformation(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            
            Name = name;
        }
    }
}