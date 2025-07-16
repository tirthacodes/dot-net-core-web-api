using dot_net_core_web_api.MyLogging;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_core_web_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : Controller
    {
        //loosely coupled dependency injection

        private readonly ILogger<DemoController> _logger;
        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            _logger.LogTrace("Log message from Trace method.");
            _logger.LogDebug("Log message from Debug method.");
            _logger.LogInformation("Log message from Information method.");
            _logger.LogWarning("Log message from Warning method.");
            _logger.LogError("Log message from Error method.");
            _logger.LogCritical("Log message from Critical method.");
            return Ok();
        }
    }
}
