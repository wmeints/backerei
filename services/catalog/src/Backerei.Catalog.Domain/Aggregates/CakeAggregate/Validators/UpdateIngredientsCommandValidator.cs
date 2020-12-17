using System.Threading;
using System.Threading.Tasks;
using Backerei.Catalog.Domain.Commands;
using FluentValidation;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate.Validators
{
    public class UpdateIngredientsCommandValidator: AbstractValidator<UpdateIngredientsCommand>
    {
        private readonly ICakeRepository _cakeRepository;

        public UpdateIngredientsCommandValidator(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
            RuleFor(x => x.Ingredients).NotEmpty();
            
            RuleFor(x => x.CakeId)
                .MustAsync(BeExistingCake)
                .WithMessage("Specified cake doesn't exist.");
            
            RuleForEach(x => x.Ingredients).ChildRules(x =>
            {
                x.RuleFor(y => y.Name).NotEmpty();
                x.RuleFor(y => y.Weight).GreaterThan(0);
            });
        }

        private Task<bool> BeExistingCake(int cakeId, CancellationToken cancellationToken)
        {
            return _cakeRepository.CakeExists(cakeId);
        }
    }
}