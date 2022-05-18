using RestAPI.Domain.Commands;
using RestAPI.Domain.Notifications;
using System.Threading.Tasks;

namespace RestAPI.Domain.MediatorHandler
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseDomainNotificationAsync<T>(T notification) where T : DomainNotification;
    }
}
