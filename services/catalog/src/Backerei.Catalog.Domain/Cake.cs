using System;
using System.Collections.Generic;
using System.Linq;

namespace Backerei.Catalog.Domain
{
    /// <summary>
    /// We're selling cakes, hence the cake. We're selling them in two shapes: square and round.
    /// You can order all sorts of cakes from different categories on the website.
    /// </summary>
    public class Cake
    {
        /// <summary>
        /// Gets the ID of the cake.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name of the cake.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the cake.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the number of people that you can serve from this cake.
        /// </summary>
        public ServingSize Serving { get; private set; }

        /// <summary>
        /// Gets the size of the cake in cm.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Gets the shape of the cake.
        /// </summary>
        public CakeShape Shape { get; private set; }

        /// <summary>
        /// Gets the category for the cake.
        /// </summary>
        public Category Category { get; private set; }

        /// <summary>
        /// Gets the ingredients for the cake.
        /// </summary>
        public ICollection<Ingredient> Ingredients { get; private set; }

        /// <summary>
        /// Creates a new cake.
        /// </summary>
        /// <param name="name">Name of the cake</param>
        /// <param name="description">Description of the new cake</param>
        /// <param name="size">Size of the cake in cm</param>
        /// <param name="servingSize">Serving size of the cake</param>
        /// <param name="cakeShape">Shape of the cake</param>
        /// <param name="category">Category for the cake</param>
        /// <returns>Returns the new cake</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static Cake Create(string name, string description, int size, ServingSize servingSize,
            CakeShape cakeShape, Category category)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            if (size <= 0) throw new ArgumentException("Size must be greater than zero", nameof(size));
            if (servingSize == null) throw new ArgumentNullException(nameof(servingSize));
            if (cakeShape == null) throw new ArgumentNullException(nameof(cakeShape));
            if (category == null) throw new ArgumentNullException(nameof(category));

            return new Cake
            {
                Name = name,
                Description = description,
                Size = size,
                Serving = servingSize,
                Shape = cakeShape,
                Category = category
            };
        }

        /// <summary>
        /// Updates the information for the cake.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="size"></param>
        /// <param name="servingSize"></param>
        /// <param name="cakeShape"></param>
        /// <param name="category"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Update(string name, string description, int size, ServingSize servingSize, CakeShape cakeShape,
            Category category)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentNullException(nameof(description));
            if (size <= 0) throw new ArgumentException("Size must be greater than zero", nameof(size));
            if (servingSize == null) throw new ArgumentNullException(nameof(servingSize));
            if (cakeShape == null) throw new ArgumentNullException(nameof(cakeShape));
            if (category == null) throw new ArgumentNullException(nameof(category));

            Name = name;
            Description = description;
            Size = size;
            Serving = servingSize;
            Shape = cakeShape;
            Category = category;
        }

        /// <summary>
        /// Adds a new ingredient to the cake
        /// </summary>
        /// <param name="name">Name of the new ingredient.</param>
        /// <param name="weight">The relative weight of the ingredient in the cake.</param>
        /// <param name="isAllergen">Whether the ingredient is an allergen.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AddIngredient(string name, int weight, bool isAllergen)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException();
            
            if (this.Ingredients.Any(x => x.Name.ToLower() == name.ToLower()))
            {
                throw new ArgumentException("Ingredient already exists.", nameof(name));
            }
            
            Ingredients.Add(Ingredient.Create(name, weight, isAllergen));
        }

        /// <summary>
        /// Updates an ingredient in the cake.
        /// </summary>
        /// <param name="id">the ID of the ingredient.</param>
        /// <param name="name">Name of the new ingredient.</param>
        /// <param name="weight">The relative weight of the ingredient in the cake.</param>
        /// <param name="isAllergen">Whether the ingredient is an allergen.</param>
        public void UpdateIngredient(int id, string name, int weight, bool isAllergen)
        {
            var ingredient = Ingredients.SingleOrDefault(x => x.Id == id);

            if (ingredient == null)
            {
                throw new IngredientNotFoundException(id);
            }

            ingredient.Update(name, weight, isAllergen);
        }
    }
}