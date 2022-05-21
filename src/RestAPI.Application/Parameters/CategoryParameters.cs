using System.Collections.Generic;

namespace RestAPI.Application.Parameters
{
    public class CategoryParameters : QueryParameters
    {
        public IEnumerable<string> Name { get; set; }

        public CategoryParameters()
        {
            Name = new List<string>();
        }
    }
}
