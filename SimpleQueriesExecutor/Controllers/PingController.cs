using Microsoft.AspNetCore.Mvc;

namespace SimpleQueriesExecutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}
