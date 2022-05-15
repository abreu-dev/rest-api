using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ServiceUnavailable()
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable, null);
        }
    }
}
