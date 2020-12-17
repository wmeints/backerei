using System;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Chill;
using FluentAssertions;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Aggregates.CakeAggregate
{
    public class WhenServingPortionsIsCreatedWithInvertedMinMax : GivenWhenThen<ServingPortions>
    {
        public WhenServingPortionsIsCreatedWithInvertedMinMax()
        {
            WhenLater(() => ServingPortions.FromRange(10,1));
        }

        [Fact]
        public void ThenAnExceptionIsThrown()
        {
            WhenAction.Should().Throw<ArgumentException>();
        }
    }
    public class WhenServingPortionsIsCreatedWithMatchingMinAndMax : GivenWhenThen<ServingPortions>
    {
        public WhenServingPortionsIsCreatedWithMatchingMinAndMax()
        {
            WhenLater(() => ServingPortions.FromRange(10,10));
        }

        [Fact]
        public void ThenAnExceptionIsThrown()
        {
            WhenAction.Should().Throw<ArgumentException>();
        }
    }
}