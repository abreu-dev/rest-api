using RestAPI.Domain.Enums;
using System;

namespace RestAPI.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int QuantityAvailable { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        public Currency Currency { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
