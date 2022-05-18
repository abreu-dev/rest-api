using FluentValidation;
using RestAPI.Domain.Commands.ProductCommands;
using RestAPI.Domain.Enums;

namespace RestAPI.Domain.Validators.ProductValidators
{
    public class AddProductCommandValidator : CommandValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.Product.Name)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Name not informed")
                .WithMessage("The field 'Name' must be informed");

            RuleFor(x => x.Product.Description)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Description not informed")
                .WithMessage("The field 'Description' must be informed");

            RuleFor(x => x.Product.QuantityAvailable)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode("MinimumValue")
                .WithState(_ => "QuantityAvailable less than zero")
                .WithMessage("The field 'QuantityAvailable' must be at least zero");

            RuleFor(x => x.Product.UnitOfMeasurement)
                .NotEqual(UnitOfMeasurement.Undefined)
                .WithErrorCode("MissingValue")
                .WithState(_ => "UnitOfMeasurement not informed")
                .WithMessage("The field 'UnitOfMeasurement' must be informed");

            RuleFor(x => x.Product.Currency)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Currency not informed")
                .WithMessage("The field 'Currency' must be informed");

            When(x => x.Product.Currency != null, () =>
            {
                RuleFor(x => x.Product.Currency.Value)
                    .GreaterThan(0)
                    .WithErrorCode("MinimumValue")
                    .WithState(_ => "Value less than or equal to zero")
                    .WithMessage("The field 'Value' must be greather than zero");

                RuleFor(x => x.Product.Currency.CurrencyCode)
                    .NotEmpty()
                    .WithErrorCode("MissingValue")
                    .WithState(_ => "CurrencyCode not informed")
                    .WithMessage("The field 'CurrencyCode' must be informed");
            });

            RuleFor(x => x.Product.CategoryId)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Category not informed")
                .WithMessage("The field 'Category' must be informed");
        }
    }
}
