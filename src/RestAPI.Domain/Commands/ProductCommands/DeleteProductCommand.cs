using RestAPI.Domain.Validators.ProductValidators;
using System;

namespace RestAPI.Domain.Commands.ProductCommands
{
    public class DeleteProductCommand : Command
    {
        public DeleteProductCommand(Guid aggregateId) : base(aggregateId) { }

        public override bool IsValid()
        {
            ValidationResult = new DeleteProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
