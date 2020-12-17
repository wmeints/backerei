using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Chill;
using FluentAssertions;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Aggregates.CakeAggregate
{
    public class WhenServingPortionsAreCompared : GivenSubject<ServingPortions>
    {
        public WhenServingPortionsAreCompared()
        {
            WithSubject(resolver => ServingPortions.FromRange(1, 10));
        }

        [Fact]
        public void ThenItsEqualToAMatchingObject()
        {
            Subject.Equals(ServingPortions.FromRange(1, 10)).Should().BeTrue();
        }

        [Fact]
        public void ThenItsNotEqualToAnUnmatchingObject()
        {
            Subject.Equals(ServingPortions.FromRange(2, 8)).Should().BeFalse();
        }
    }
}