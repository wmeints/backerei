using System;

namespace Backerei.Catalog.Domain.Aggregates.PieAggregate
{
    /// <summary>
    /// Represents a single ingredient in a cake with its relative weight.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Ingredient"/>.
        /// </summary>
        /// <param name="name">Name of the ingredient.</param>
        /// <param name="isAllergen">Flag indicating the ingredient is an allergen.</param>
        /// <param name="relativeAmount">Relative amount in the ingredient.</param>
        public Ingredient(string name, bool isAllergen, double relativeAmount)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsAllergen = isAllergen;
            RelativeAmount = relativeAmount;
        }

        /// <summary>
        /// Gets the ID of the ingredient.
        /// </summary>
        public Guid Id { get; private set; }
        
        /// <summary>
        /// Gets the name of the ingredient.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Gets whether the ingredient is considered an allergen.
        /// </summary>
        public bool IsAllergen { get; private set; }
        
        
        /// <summary>
        /// Gets the relative amount of the ingredient in the cake recipe.
        /// </summary>
        public double RelativeAmount { get; private set; }
    }
}