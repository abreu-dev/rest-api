using Moq;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Services;
using RestAPI.Infra.Data.Context;
using Xunit;

namespace RestAPI.Application.Tests.Services
{
    public class HealthServiceTests
    {
        private readonly Mock<IRestApiDbContext> _restApiDbContext;
        private readonly IHealthService _healthService;

        public HealthServiceTests()
        {
            _restApiDbContext = new Mock<IRestApiDbContext>();
            _healthService = new HealthService(_restApiDbContext.Object);
        }

        [Fact]
        public void IsHealthy_ShouldReturnTrue_WhenServicesAvailable()
        {
            // Arrange
            _restApiDbContext.Setup(x => x.IsAvailable()).Returns(true);

            // Act
            var isHealthy = _healthService.IsHealthy();

            // Assert
            Assert.True(isHealthy);
        }

        [Fact]
        public void IsHealthy_ShouldReturnFalse_WhenServicesNotAvailable()
        {
            // Arrange
            _restApiDbContext.Setup(x => x.IsAvailable()).Returns(false);

            // Act
            var isHealthy = _healthService.IsHealthy();

            // Assert
            Assert.False(isHealthy);
        }
    }
}
