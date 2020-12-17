using System;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Chill;
using FluentAssertions;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Aggregates.CakeAggregate
{
    public class WhenServingPortionsIsCreatedWithInvalidMinimum: GivenWhenThen<ServingPortions>
    {
        public WhenServingPortionsIsCreatedWithInvalidMinimum()
        {
            WhenLater(() => ServingPortions.FromRange(0, 10));
        }

        [Fact]
        public void ThenAnExceptionIsThrown()
        {
            WhenAction.Should().Throw<ArgumentException>();
        }
    }
}