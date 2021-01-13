using Backerei.Catalog.Domain.Aggregates.PieAggregate.Commands;
using FluentValidation;

namespace Backerei.Catalog.Domain.Aggregates.PieAggregate.Validators
{
    /// <summary>
    /// Validates <see cref="UpdatePieDetailsCommand"/>.
    /// </summary>
    public class UpdatePieDetailsCommandValidator : AbstractValidator<UpdatePieDetailsCommand>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UpdatePieDetailsCommandValidator"/>
        /// </summary>
        public UpdatePieDetailsCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}