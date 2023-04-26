using Microsoft.AspNetCore.Mvc;

namespace Anki.Domain.Controllers
{
    [ApiController]
    public class HomeController: ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get()
        {
            return Ok("Ok");
        }

        [HttpGet("/v1")]
        public IActionResult GetV1()
        {
            return Ok("/v1 ativa.");
        }
    }
}
