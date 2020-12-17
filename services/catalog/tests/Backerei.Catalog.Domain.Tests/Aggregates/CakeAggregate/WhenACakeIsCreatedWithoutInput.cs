using System;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Chill;
using FluentAssertions;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Aggregates.CakeAggregate
{
    public class WhenACakeIsCreatedWithoutInput : GivenWhenThen<Cake>
    {
        public WhenACakeIsCreatedWithoutInput()
        {
            When(() => Cake.Create(null), deferredExecution: true);
        }

        [Fact]
        public void ThenAnExceptionIsRaised()
        {
            WhenAction.Should().Throw<ArgumentNullException>();
        }
    }
}