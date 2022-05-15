using RestAPI.Domain.Enums;
using RestAPI.Domain.Interfaces;
using System;

namespace RestAPI.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int QuantityAvailable { get; set; }
        public bool IsActive { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        public Currency Currency { get; set; }

        public Guid CategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}
