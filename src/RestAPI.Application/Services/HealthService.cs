using RestAPI.Application.Interfaces;
using RestAPI.Infra.Data.Context;

namespace RestAPI.Application.Services
{
    public class HealthService : IHealthService
    {
        private readonly IRestApiDbContext _restApiDbContext;

        public HealthService(IRestApiDbContext restApiDbContext)
        {
            _restApiDbContext = restApiDbContext;
        }

        public bool IsHealthy()
        {
            return _restApiDbContext.IsAvailable();
        }
    }
}
