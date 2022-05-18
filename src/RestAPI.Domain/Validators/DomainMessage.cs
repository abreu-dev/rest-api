namespace RestAPI.Domain.Validators
{
    public class DomainMessage
    {
        public string Type { get; set; }
        public string Error { get; set; }
        public string Detail { get; set; }

        public DomainMessage(string type, string error, string detail)
        {
            Type = type;
            Error = error;
            Detail = detail;
        }
    }
}
