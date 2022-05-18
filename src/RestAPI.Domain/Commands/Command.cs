using FluentValidation.Results;
using MediatR;
using System;

namespace RestAPI.Domain.Commands
{
    public abstract class Command : IRequest<Unit>
    {
        public ValidationResult ValidationResult { get; set; } 
        public string MessageType { get; set; }
        public Guid AggregateId { get; set; }
        public DateTime Timestamp { get; set; }

        protected Command(Guid aggregateId)
        {
            AggregateId = aggregateId;
            MessageType = GetType().Name;
            Timestamp = DateTime.UtcNow;
        }

        public abstract bool IsValid();
    }
}
