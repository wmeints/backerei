using System;
using System.Collections.Generic;
using System.Linq;
using Backerei.Catalog.Domain.Aggregates.PieAggregate.Commands;
using Backerei.Catalog.Domain.Aggregates.PieAggregate.Events;
using Backerei.Catalog.Domain.Aggregates.PieAggregate.Validators;
using Backerei.Catalog.Domain.Common;

namespace Backerei.Catalog.Domain.Aggregates.PieAggregate
{
    /// <summary>
    /// Represents a cake that's sold in the bakery, including its ingredients for the label.
    /// </summary>
    public class Pie
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();

        /// <summary>
        /// Initializes a new instance of <see cref="Pie"/>.
        /// </summary>
        private Pie()
        {
        }

        /// <summary>
        /// Gets the ID of the cake.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the name of the cake.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the cake.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the ingredients in the cake.
        /// </summary>
        public IEnumerable<Ingredient> Ingredients => _ingredients;

        /// <summary>
        /// Creates a new cake in the catalog.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static OperationResult<Pie> Register(IntroducePieCommand cmd)
        {
            var result = new OperationResult<Pie>();
            var validator = new IntroducePieCommandValidator();
            var validationResult = validator.Validate(cmd);

            if (validationResult.IsValid)
            {
                var cake = new Pie
                {
                    Id = Guid.NewGuid(),
                    Name = cmd.Name,
                    Description = cmd.Description
                };

                var createdEvent = new CakeIntroducedEvent
                {
                    PieId = cake.Id,
                    Description = cake.Description,
                    Name = cake.Name
                };
                
                return result.WithOutput(cake).WithDomainEvent(createdEvent);
            }

            return result.WithValidationResult(validationResult);
        }

        /// <summary>
        /// Updates the product details of the cake.
        /// </summary>
        /// <param name="cmd">Command data to use for the operation.</param>
        /// <returns>Returns the outcome of the operation.</returns>
        public OperationResult UpdateProductDetails(UpdatePieDetailsCommand cmd)
        {
            var result = new OperationResult();
            var validator = new UpdatePieDetailsCommandValidator();
            var validationResult = validator.Validate(cmd);

            if (validationResult.IsValid)
            {
                Name = cmd.Name;
                Description = cmd.Description;

                _ingredients.Clear();
                _ingredients.AddRange(cmd.Ingredients.Select(x => 
                    new Ingredient(x.Name,x.IsAllergen,x.RelativeAmount)));
                
                return result.WithDomainEvent(new PieDetailsUpdatedEvent
                {
                    PieId = Id,
                    Name = Name,
                    Description = Description
                });
            }

            return result.WithValidationResult(validationResult);
        }
    }
}