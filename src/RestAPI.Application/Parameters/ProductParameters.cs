using RestAPI.Domain.Enums;
using System;
using System.Collections.Generic;

namespace RestAPI.Application.Parameters
{
    public class ProductParameters : QueryParameters 
    {
        public IEnumerable<string> Name { get; set; }
        public int? MinQuantityAvailable { get; set; }
        public int? MaxQuantityAvailable { get; set; }
        public bool? IsActive { get; set; }
        public IEnumerable<string> Category { get; set; }
        public UnitOfMeasurement? UnitOfMeasurement { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public DateTime? MinCreatedAt { get; set; }
        public DateTime? MaxCreatedAt { get; set; }

        public ProductParameters()
        {
            Name = new List<string>();
            Category = new List<string>();
        }
    }
}
