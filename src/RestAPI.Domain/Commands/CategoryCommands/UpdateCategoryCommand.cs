using RestAPI.Domain.Entities;
using RestAPI.Domain.Validators.CategoryValidators;
using System;

namespace RestAPI.Domain.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : Command
    {
        public Category Category { get; set; }

        public UpdateCategoryCommand(Guid aggregateId) : base(aggregateId) { }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoryCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
