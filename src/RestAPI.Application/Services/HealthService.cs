using RestAPI.Application.Interfaces;

namespace RestAPI.Application.Services
{
    public class HealthService : IHealthService
    {
        public bool IsHealthy()
        {
            return false;
        }
    }
}
