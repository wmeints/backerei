using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using Chill;
using FluentAssertions;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Aggregates.CakeAggregate
{
    public class WhenAnExistingCakeIsUpdated : GivenSubject<Cake>
    {
        public WhenAnExistingCakeIsUpdated()
        {
            WithSubject(resolver => Cake.Create(new CreateCakeCommand()
            {
                CategoryId = 1,
                Name = "test",
                Description = "test",
                Shape = CakeShape.Round,
                Size = 24,
                ServingPortions = ServingPortions.FromRange(8, 10)
            }));
            
            When(() => Subject.Update(new UpdateCakeCommand()
            {
                Name = "test2",
                Description = "test2",
                Shape = CakeShape.Square,
                Size = 30,
                CategoryId = 2,
                ServingPortions = ServingPortions.FromRange(9, 16)
            }));
        }

        [Fact]
        public void ThenTheNameIsUpdated()
        {
            Subject.Name.Should().Be("test2");
        }
        
        [Fact]
        public void ThenTheDescriptionIsUpdated()
        {
            Subject.Description.Should().Be("test2");
        }
        
        [Fact]
        public void ThenTheShapeIsUpdated()
        {
            Subject.Shape.Should().Be(CakeShape.Square);
        }

        [Fact]
        public void ThenTheSizeIsUpdated()
        {
            Subject.Size.Should().Be(30);
        }

        [Fact]
        public void ThenTheServingPortionsAreUpdated()
        {
            Subject.ServingPortions.Should().Be(ServingPortions.FromRange(9, 16));
        }

        [Fact]
        public void ThenTheCategoryIsUpdated()
        {
            Subject.CategoryId.Should().Be(2);
        }
    }
}