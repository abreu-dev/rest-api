using FluentValidation;
using RestAPI.Domain.Commands;

namespace RestAPI.Domain.Validators
{
    public abstract class CommandValidator<T> : AbstractValidator<T> where T : Command { }
}
