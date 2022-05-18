using FluentValidation;
using RestAPI.Domain.Commands.CategoryCommands;

namespace RestAPI.Domain.Validators.CategoryValidators
{
    public class UpdateCategoryCommandValidator : CommandValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.AggregateId)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Id not informed")
                .WithMessage("The field 'Id' must be informed");

            RuleFor(x => x.Category.Name)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Name not informed")
                .WithMessage("The field 'Name' must be informed");
        }
    }
}
