using FluentValidation;
using RestAPI.Domain.Commands.ProductCommands;

namespace RestAPI.Domain.Validators.ProductValidators
{
    public class UpdateProductCommandValidator : CommandValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.AggregateId)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Id not informed")
                .WithMessage("The field 'Id' must be informed");

            RuleFor(x => x.Product.Name)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Name not informed")
                .WithMessage("The field 'Name' must be informed");
        }
    }
}
