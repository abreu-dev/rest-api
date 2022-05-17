using System;

namespace RestAPI.Application.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int QuantityAvailable { get; set; }
        public bool IsActive { get; set; }
        public string UnitOfMeasurement { get; set; }
        public CurrencyDTO Currency { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
