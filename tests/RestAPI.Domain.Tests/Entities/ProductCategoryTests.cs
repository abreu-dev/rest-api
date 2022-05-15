using RestAPI.Domain.Entities;
using System;
using Xunit;

namespace RestAPI.Domain.Tests.Entities
{
    public class ProductCategoryTests
    {
        [Fact]
        public void Constructor_ShouldCreateInstance()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Category";

            // Act
            var category = new ProductCategory()
            {
                Id = id,
                Name = name
            };

            // Assert
            Assert.Equal(id, category.Id);
            Assert.Equal(name, category.Name);
        }
    }
}
