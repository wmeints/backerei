using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Chill;
using FluentAssertions;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Aggregates.CakeAggregate
{
    public class WhenServingPortionsIsCreatedWithAValidRange: GivenWhenThen<ServingPortions>
    {
        public WhenServingPortionsIsCreatedWithAValidRange()
        {
            When(() => ServingPortions.FromRange(1,10));
        }

        [Fact]
        public void ThenTheMaximumIsSpecified()
        {
            Result.Maximum.Should().Be(10);
        }

        [Fact]
        public void ThenTheMinimumIsSpecified()
        {
            Result.Minimum.Should().Be(1);
        }
    }
}