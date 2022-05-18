using Microsoft.AspNetCore.Mvc;
using RestAPI.Application.Interfaces;

namespace RestAPI.API.Controllers
{
    public class HealthController : BaseController
    {
        private readonly IHealthService _healthService;

        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        /// <summary>
        /// Verifica se todas as conexões que o serviço utiliza estão funcionando normalmente
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Serviço funcionando normalmente</response>
        /// <response code="503">Serviço está com problema</response>
        [HttpGet]
        [Route("health")]
        public IActionResult Get()
        {
            if (_healthService.IsHealthy())
            {
                return Ok();
            }

            return ServiceUnavailable();
        }
    }
}
