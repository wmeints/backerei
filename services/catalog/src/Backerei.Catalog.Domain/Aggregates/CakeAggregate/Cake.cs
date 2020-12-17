using System;
using System.Collections.Generic;
using System.Linq;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using Backerei.Catalog.Domain.Commands;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate
{
    /// <summary>
    /// We're selling cakes, hence the cake. We're selling them in two shapes: square and round.
    /// You can order all sorts of cakes from different categories on the website.
    /// </summary>
    public class Cake
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Cake"/>
        /// </summary>
        private Cake()
        {
            
        }

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
        public ServingPortions ServingPortions { get; private set; }

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
        public int CategoryId { get; private set; }

        /// <summary>
        /// Gets the ingredients for the cake.
        /// </summary>
        public ICollection<Ingredient> Ingredients { get; private set; } = new List<Ingredient>();

        /// <summary>
        /// Creates a new cake.
        /// </summary>
        /// <param name="cmd">Data to create the new cake</param>
        public static Cake Create(CreateCakeCommand cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            
            return new Cake
            {
                CategoryId = cmd.CategoryId,
                Description = cmd.Description,
                Name = cmd.Name,
                Shape = cmd.Shape,
                Size = cmd.Size,
                ServingPortions = cmd.ServingPortions
            };
        }

        /// <summary>
        /// Updates the information for the cake.
        /// </summary>
        /// <param name="cmd">Command data for the operation.</param>
        public void Update(UpdateCakeCommand cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            
            Name = cmd.Name;
            Description = cmd.Description;
            Size = cmd.Size;
            ServingPortions = cmd.ServingPortions;
            CategoryId = cmd.CategoryId;
            Shape = cmd.Shape;
        }

        /// <summary>
        /// Updates the ingredients of the cake.
        /// </summary>
        /// <param name="cmd">Command data for the operation.</param>
        public void UpdateIngredients(UpdateIngredientsCommand cmd)
        {
            if (cmd == null) throw new ArgumentNullException(nameof(cmd));
            
            Ingredients.Clear();

            foreach (var ingredient in cmd.Ingredients)
            {
                Ingredients.Add(Ingredient.Create(ingredient.Name, ingredient.Weight, ingredient.IsAllergen));
            }
        }
    }
}