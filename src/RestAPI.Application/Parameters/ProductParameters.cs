using System.Collections.Generic;

namespace RestAPI.Application.Parameters
{
    public class ProductParameters : QueryParameters 
    {
        public IEnumerable<string> Name { get; set; }
        public int? MinQuantityAvailable { get; set; }
        public int? MaxQuantityAvailable { get; set; }
        public bool? IsActive { get; set; }
    }
}
