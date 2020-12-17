using System.Threading;
using System.Threading.Tasks;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using Backerei.Catalog.Domain.Aggregates.CategoryAggregate;
using FluentValidation;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate.Validators
{
    public class CreateCakeCommandValidator: AbstractValidator<CreateCakeCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCakeCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CreateCakeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().MaximumLength(150);
            
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);
            
            RuleFor(x => x.Size)
                .GreaterThan(0)
                .LessThanOrEqualTo(40);
            
            RuleFor(x => x.CategoryId)
                .MustAsync(ExistInTheDatabase)
                .WithMessage("Category must exist.");
        }

        private async Task<bool> ExistInTheDatabase(int categoryId, CancellationToken cancellationToken)
        {
            return await _categoryRepository.CategoryExists(categoryId);
        }
    }
}