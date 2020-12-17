using System;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using Chill;
using FluentAssertions;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Aggregates.CakeAggregate
{
    public class WhenAnExistingCakeIsUpdatedWithoutInput : GivenSubject<Cake>
    {
        public WhenAnExistingCakeIsUpdatedWithoutInput()
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
            
            WhenLater(() => Subject.Update(null));
        }

        [Fact]
        public void ThenAnExceptionIsRaised()
        {
            WhenAction.Should().Throw<ArgumentNullException>();
        }
    }
}