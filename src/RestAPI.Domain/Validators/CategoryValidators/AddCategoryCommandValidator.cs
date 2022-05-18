using FluentValidation;
using RestAPI.Domain.Commands.CategoryCommands;

namespace RestAPI.Domain.Validators.CategoryValidators
{
    public class AddCategoryCommandValidator : CommandValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Category.Name)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Name not informed")
                .WithMessage("The field 'Name' must be informed");
        }
    }
}
