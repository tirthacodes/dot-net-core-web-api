using dot_net_core_web_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_core_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> GetStudentName()
        {
            return new List<Student> {
                new Student
                {
                    Id = 1,
                    StudentName = "Binay",
                    Email = "binay@gmail.com",
                    Address = "KTM"
                },
                new Student
                {
                    Id = 2,
                    StudentName = "Alex",
                    Email = "alex@gmail.com",
                    Address = "Baglung"
                }
            };
        }
    }
}
