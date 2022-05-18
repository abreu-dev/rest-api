using RestAPI.Domain.Entities;
using RestAPI.Domain.Validators.ProductValidators;
using System;

namespace RestAPI.Domain.Commands.ProductCommands
{
    public class AddProductCommand : Command
    {
        public Product Product { get; set; }

        public AddProductCommand() : base(Guid.Empty) { }

        public override bool IsValid()
        {
            ValidationResult = new AddProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
