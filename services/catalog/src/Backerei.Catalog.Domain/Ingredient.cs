using System;

namespace Backerei.Catalog.Domain
{
    /// <summary>
    /// Represents an ingredient that was used in making the cake.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Ingredient"/>
        /// </summary>
        private Ingredient()
        {
            
        }
        
        /// <summary>
        /// Gets the ID of the ingredient.
        /// </summary>
        public int Id { get; private set; }
        
        /// <summary>
        /// Gets the name of the ingredient.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Gets whether the ingredient is considered an allergen.
        /// </summary>
        public bool IsAllergen { get; private set; }

        /// <summary>
        /// The relative weight of the ingredient in the cake.
        /// </summary>
        public int Weight { get; private set; }
        
        /// <summary>
        /// Creates a new ingredient
        /// </summary>
        /// <param name="name">Name of the ingredient.</param>
        /// <param name="weight">The relative weight of the ingredient in the cake.</param>
        /// <param name="isAllergen">Whether the ingredient is an allergen.</param>
        /// <returns>Returns the new ingredient.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Ingredient Create(string name, int weight, bool isAllergen)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return new Ingredient {Name = name, IsAllergen = isAllergen};
        }

        /// <summary>
        /// Updates the details of the ingredient.
        /// </summary>
        /// <param name="name">Name of the ingredient.</param>
        /// <param name="weight">Relative weight of the ingredient in the cake.</param>
        /// <param name="isAllergen">Whether the ingredient is an allergen.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(string name, int weight, bool isAllergen)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
            Weight = weight;
            IsAllergen = isAllergen;
        }
    }
}