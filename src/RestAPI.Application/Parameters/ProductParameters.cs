namespace RestAPI.Application.Parameters
{
    public class ProductParameters : QueryStringParameters
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
