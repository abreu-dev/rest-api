using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.API.Controllers
{
    [ApiController]
    [Route("api")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ServiceUnavailable()
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable, null);
        }
    }
}
