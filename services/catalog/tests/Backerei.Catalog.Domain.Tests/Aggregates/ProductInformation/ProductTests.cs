using System.Linq;
using Backerei.Catalog.Domain.Aggregates.ProductInformation;
using FluentAssertions;
using Xunit;

namespace Backerei.Catalog.Domain.Tests.Aggregates.ProductInformation
{
    public class ProductTests
    {
        [Fact]
        public void Create_WithValidInput_ReturnsProduct()
        {
            var result = Product.Create("Test", "Test", 1.95);

            result.IsValid.Should().BeTrue();
            result.Output.Should().NotBeNull();
        }

        [Fact]
        public void Create_MissingName_ReturnsValidationError()
        {
            var result = Product.Create("", "Test", 1.95);

            result.IsValid.Should().BeFalse();
            result.Output.Should().BeNull();
            result.ValidationErrors["name"].First().Should().Be("Name is required.");
        }

        [Fact]
        public void Create_MissingDescription_ReturnsValidationError()
        {
            var result = Product.Create("Test", "", 1.95);

            result.IsValid.Should().BeFalse();
            result.Output.Should().BeNull();
            result.ValidationErrors["description"].First().Should().Be("Description is required.");
        }
        
        [Fact]
        public void Create_InvalidPrice_ReturnsValidationError()
        {
            var result = Product.Create("Test", "Test", -10.0);

            result.IsValid.Should().BeFalse();
            result.Output.Should().BeNull();
            result.ValidationErrors["price"].First().Should().Be("The price must be above zero.");
        }

        [Fact]
        public void UpdateProductInformation_ValidInformation_ReturnsOutcome()
        {
            var createResult = Product.Create("Test", "Test", 10.35);
            var updateResult = createResult.Output.UpdateDetails("Test2", "Test2", 1.95);

            updateResult.IsValid.Should().BeTrue();
        }

        [Fact]
        public void UpdateProductInformation_MissingName_ReturnsValidationError()
        {
            var createResult = Product.Create("Test", "Test", 10.35);
            var updateResult = createResult.Output.UpdateDetails("", "Test2", 1.95);

            updateResult.IsValid.Should().BeFalse();
            updateResult.ValidationErrors["name"][0].Should().Be("Name is required.");
        }
        
        [Fact]
        public void UpdateProductInformation_MissingDescription_ReturnsValidationError()
        {
            var createResult = Product.Create("Test", "Test", 10.35);
            var updateResult = createResult.Output.UpdateDetails("Test2", "", 1.95);

            updateResult.IsValid.Should().BeFalse();
            updateResult.ValidationErrors["description"][0].Should().Be("Description is required.");
        }
        
        [Fact]
        public void UpdateProductInformation_InvalidPrice_ReturnsValidationError()
        {
            var createResult = Product.Create("Test", "Test", 10.35);
            var updateResult = createResult.Output.UpdateDetails("Test2", "Test2", -1.95);

            updateResult.IsValid.Should().BeFalse();
            updateResult.ValidationErrors["price"][0].Should().Be("The price must be above zero.");
        }
    }
}