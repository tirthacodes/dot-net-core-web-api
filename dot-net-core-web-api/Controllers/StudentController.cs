using Microsoft.AspNetCore.Mvc;

namespace dot_net_core_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public string GetStudentName()
        {
            return "Student Name: Ronaldo suii";
        }
    }
}
