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
            return CollegeRepository.Students;
        }

        [HttpGet("{id:int}")]
        public Student GetStudentbyId(int id)
        {
            return CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();
        }
    }
}
