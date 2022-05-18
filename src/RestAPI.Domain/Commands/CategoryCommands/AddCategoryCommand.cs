using RestAPI.Domain.Entities;
using RestAPI.Domain.Validators.CategoryValidators;
using System;

namespace RestAPI.Domain.Commands.CategoryCommands
{
    public class AddCategoryCommand : Command
    {
        public Category Category { get; set; }

        public AddCategoryCommand() : base(Guid.Empty) { }

        public override bool IsValid()
        {
            ValidationResult = new AddCategoryCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
