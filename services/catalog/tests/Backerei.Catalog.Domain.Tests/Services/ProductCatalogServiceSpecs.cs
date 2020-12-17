using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using Backerei.Catalog.Domain.Aggregates.CategoryAggregate;
using Backerei.Catalog.Domain.Services;
using Chill;
using NSubstitute;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Services
{
    public class WhenCreateProductIsExecuted : GivenSubject<ProductCatalogService>
    {
        public WhenCreateProductIsExecuted()
        {
            SetThe<ICakeRepository>().To(Substitute.For<ICakeRepository>());
            SetThe<ICategoryRepository>().To(Substitute.For<ICategoryRepository>());
            
            WithSubject(resolver => new ProductCatalogService(
                resolver.Get<ICategoryRepository>(),
                resolver.Get<ICakeRepository>()));

            When(() => Subject.CreateCake(new CreateCakeCommand()
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
        public void ThenTheCakeIsStored()
        {
            The<ICakeRepository>().Received().Insert(Arg.Any<Cake>());
        }
    }
}