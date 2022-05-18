using FluentValidation;
using RestAPI.Domain.Commands.CategoryCommands;

namespace RestAPI.Domain.Validators.CategoryValidators
{
    public class DeleteCategoryCommandValidator : CommandValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.AggregateId)
                .NotEmpty()
                .WithErrorCode("MissingValue")
                .WithState(_ => "Id not informed")
                .WithMessage("The field 'Id' must be informed");
        }
    }
}
