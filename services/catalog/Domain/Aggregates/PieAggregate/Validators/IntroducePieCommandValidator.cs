using Backerei.Catalog.Domain.Aggregates.PieAggregate.Commands;
using FluentValidation;

namespace Backerei.Catalog.Domain.Aggregates.PieAggregate.Validators
{
    /// <summary>
    /// Validates the <see cref="IntroducePieCommand"/>.
    /// </summary>
    public class IntroducePieCommandValidator: AbstractValidator<IntroducePieCommand>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IntroducePieCommandValidator"/>
        /// </summary>
        public IntroducePieCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}