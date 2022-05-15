using RestAPI.Domain.Entities;
using Xunit;

namespace RestAPI.Domain.Tests.Entities
{
    public class CurrencyTests
    {
        [Fact]
        public void Constructor_ShouldCreateInstance()
        {
            // Arrange
            var value = 15.78;
            var currencyCode = "BRL";

            // Act
            var currency = new Currency()
            {
                Value = value,
                CurrencyCode = currencyCode
            };

            // Assert
            Assert.Equal(value, currency.Value);
            Assert.Equal(currencyCode, currency.CurrencyCode);
        }
    }
}
