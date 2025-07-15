using dot_net_core_web_api.MyLogging;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_core_web_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : Controller
    {
        //loosely coupled dependency injection

        private readonly IMyLogger _myLogger;
        public DemoController(IMyLogger myLogger)
        {
            _myLogger = myLogger;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            _myLogger.Log("Index method started");
            return Ok();
        }
    }
}
