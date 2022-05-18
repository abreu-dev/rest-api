using FluentValidation;
using RestAPI.Domain.Commands.ProductCommands;

namespace RestAPI.Domain.Validators.ProductValidators
{
    public class DeleteProductCommandValidator : CommandValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.AggregateId)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Id not informed")
                .WithMessage("The field 'Id' must be informed");
        }
    }
}
