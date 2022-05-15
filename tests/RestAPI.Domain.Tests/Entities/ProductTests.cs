using RestAPI.Domain.Entities;
using RestAPI.Domain.Enums;
using System;
using Xunit;

namespace RestAPI.Domain.Tests.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_ShouldCreateInstance()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Product";
            var description = "Product Description";
            var image = "Product Image";
            var quantityAvailable = 10;
            var isActive = true;
            var unitOfMeasurement = UnitOfMeasurement.Amount;
            var currency = new Currency()
            {
                Value = 15.78,
                CurrencyCode = "BRL"
            };
            var category = new ProductCategory()
            {
                Id = Guid.NewGuid(),
                Name = "Category"
            };

            // Act
            var product = new Product()
            {
                Id = id,
                Name = name,
                Description = description,
                Image = image,
                QuantityAvailable = quantityAvailable,
                IsActive = isActive,
                UnitOfMeasurement = unitOfMeasurement,
                Currency = currency,
                CategoryId = category.Id,
                Category = category
            };

            // Assert
            Assert.Equal(id, product.Id);
            Assert.Equal(name, product.Name);
            Assert.Equal(description, product.Description);
            Assert.Equal(image, product.Image);
            Assert.Equal(quantityAvailable, product.QuantityAvailable);
            Assert.Equal(isActive, product.IsActive);
            Assert.Equal(unitOfMeasurement, product.UnitOfMeasurement);
            Assert.Equal(currency, product.Currency);
            Assert.Equal(category.Id, product.CategoryId);
            Assert.Equal(category, product.Category);
        }
    }
}
