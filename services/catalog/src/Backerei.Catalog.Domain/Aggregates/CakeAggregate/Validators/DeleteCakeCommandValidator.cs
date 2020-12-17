using System.Threading;
using System.Threading.Tasks;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using FluentValidation;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate.Validators
{
    public class DeleteCakeCommandValidator :AbstractValidator<DeleteCakeCommand>
    {
        private readonly ICakeRepository _cakeRepository;
        
        public DeleteCakeCommandValidator(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
            
            RuleFor(x => x.CakeId)
                .MustAsync(BeExistingCake)
                .WithMessage("Specified cake doesn't exist.");
        }

        private Task<bool> BeExistingCake(int cakeId, CancellationToken cancellationToken)
        {
            return _cakeRepository.CakeExists(cakeId);
        }
    }
}