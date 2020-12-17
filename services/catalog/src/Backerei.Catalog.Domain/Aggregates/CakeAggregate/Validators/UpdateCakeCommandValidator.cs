using System.Threading;
using System.Threading.Tasks;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using Backerei.Catalog.Domain.Aggregates.CategoryAggregate;
using FluentValidation;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate.Validators
{
    public class UpdateCakeCommandValidator :AbstractValidator<UpdateCakeCommand>
    {
        private readonly ICakeRepository _cakeRepository;
        private readonly ICategoryRepository _categoryRepository;
        
        public UpdateCakeCommandValidator(ICakeRepository cakeRepository, ICategoryRepository categoryRepository)
        {
            _cakeRepository = cakeRepository;
            _categoryRepository = categoryRepository;

            RuleFor(x => x.CakeId)
                .MustAsync(BeExistingCake)
                .WithMessage("Specified cake doesn't exist");
            
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);
            
            RuleFor(x => x.Size)
                .GreaterThan(0)
                .LessThanOrEqualTo(40);
            
            RuleFor(x => x.CategoryId)
                .MustAsync(BeExistingCategory)
                .WithMessage("Category must exist.");
        }

        private Task<bool> BeExistingCategory(int categoryId, CancellationToken cancellationToken)
        {
            return _categoryRepository.CategoryExists(categoryId);
        }

        private Task<bool> BeExistingCake(int cakeId, CancellationToken cancellationToken)
        {
            return _cakeRepository.CakeExists(cakeId);
        }
    }
}