using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using Backerei.Catalog.Domain.Commands;
using Chill;
using FluentAssertions;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Aggregates.CakeAggregate
{
    public class WhenIngredientsForAnExistingCakeAreUpdated : GivenSubject<Cake>
    {
        public WhenIngredientsForAnExistingCakeAreUpdated()
        {
            WithSubject(resolver => Cake.Create(new CreateCakeCommand()
            {
                Name = "test",
                Description = "test",
                Size = 24,
                Shape = CakeShape.Round,
                CategoryId = 1,
                ServingPortions = ServingPortions.FromRange(9, 16)
            }));

            When(() => Subject.UpdateIngredients(new UpdateIngredientsCommand()
            {
                Ingredients = new[]
                {
                    new IngredientDTO {Name = "Flower", Weight = 1, IsAllergen = true}
                }
            }));
        }

        [Fact]
        public void ThenTheIngredientsAreUpdated()
        {
            Subject.Ingredients.Should().Contain(x => x.Name == "Flower" && x.Weight == 1 && x.IsAllergen == true);
        }
    }
}