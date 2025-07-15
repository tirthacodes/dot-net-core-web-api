using dot_net_core_web_api.MyLogging;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_core_web_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : Controller
    {


        private readonly IMyLogger _myLogger;
        public DemoController()
        {
            _myLogger = new LogToFile();
        }

        [HttpGet]
        public IActionResult Index()
        {
            _myLogger.Log("Index method started");
            return Ok();
        }
    }
}
