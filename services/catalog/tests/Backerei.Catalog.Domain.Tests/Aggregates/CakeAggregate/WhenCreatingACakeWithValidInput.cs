using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using Chill;
using FluentAssertions;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Aggregates.CakeAggregate
{
    public class WhenCreatingACakeWithValidInput : GivenWhenThen<Cake>
    {
        public WhenCreatingACakeWithValidInput()
        {
            When(() => Cake.Create(new CreateCakeCommand()
            {
                Name = "test",
                Description = "test",
                Shape = CakeShape.Round,
                Size = 24,
                CategoryId = 1,
                ServingPortions = ServingPortions.FromRange(8, 10)
            }));
        }

        [Fact]
        public void ThenTheCakeIsReturned()
        {
            Result.Should().NotBeNull();
        }

        [Fact]
        public void ThenTheNameIsSpecified()
        {
            Result.Name.Should().Be("test");
        }

        [Fact]
        public void ThenTheDescriptionIsSpecified()
        {
            Result.Description.Should().Be("test");
        }

        [Fact]
        public void ThenTheSizeIsSpecified()
        {
            Result.Size.Should().Be(24);
        }

        [Fact]
        public void ThenTheServingPortionsAreSpecified()
        {
            Result.ServingPortions.Should().Be(ServingPortions.FromRange(8, 10));
        }

        [Fact]
        public void ThenTheShapeIsSpecified()
        {
            Result.Shape.Should().Be(CakeShape.Round);
        }

        [Fact]
        public void ThenTheCategoryIsSpecified()
        {
            Result.CategoryId.Should().Be(1);
        }
    }
}