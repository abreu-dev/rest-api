using MediatR;
using RestAPI.Domain.Commands;
using RestAPI.Domain.Notifications;
using System.Threading.Tasks;

namespace RestAPI.Domain.MediatorHandler
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendCommand<T>(T command) where T : Command
        {
            await _mediator.Send(command);
        }

        public async Task RaiseDomainNotificationAsync<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }
    }
}
