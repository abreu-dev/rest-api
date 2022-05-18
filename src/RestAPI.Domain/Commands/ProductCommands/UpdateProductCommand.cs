using RestAPI.Domain.Entities;
using RestAPI.Domain.Validators.ProductValidators;
using System;

namespace RestAPI.Domain.Commands.ProductCommands
{
    public class UpdateProductCommand : Command
    {
        public Product Product { get; set; }

        public UpdateProductCommand(Guid aggregateId) : base(aggregateId) { }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
