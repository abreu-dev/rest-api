using MediatR;

namespace RestAPI.Domain.Notifications
{
    public class DomainNotification : INotification
    {
        public string Type { get; set; }
        public string Error { get; set; }
        public string Detail { get; set; }

        public DomainNotification(string type, string error, string detail)
        {
            Type = type;
            Error = error;
            Detail = detail;
        }
    }
}
