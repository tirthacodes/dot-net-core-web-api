using dot_net_core_web_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_core_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudentName()
        {
            //Ok - 200 means success
            return Ok(CollegeRepository.Students);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudentbyId(int id)
        {
            //bad request - 400 - client error
            if(id <= 0)
            {
                return BadRequest();
            }

            var student = CollegeRepository.Students.Where(n => n.Id == id).FirstOrDefault();

            //notfound 404
            if(student == null)
            {
                return NotFound($"The student with id {id} not found.");
            }

            //ok - success 200
            return Ok(student);
        }

        private Student GetStudentbyIdInfo(int id)
        {
            return CollegeRepository.Students.FirstOrDefault(s => s.Id == id);
        }


        [HttpGet("{name:alpha}")]
        public ActionResult<Student> GetStudentbyName(string name)
        {

            //bad request - 400 - client error
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var student = CollegeRepository.Students.Where(n => n.StudentName == name).FirstOrDefault();

            //notfound 404
            if (student == null)
            {
                return NotFound($"The student with name {name} not found.");
            }


            //200 = ok success
            return Ok(student);
        }

        [HttpDelete("{id:int}", Name ="DeleteStudentbyID")]
        public ActionResult<string> DeleteStudentbyID(int id)
        {
            var student = GetStudentbyIdInfo(id);
            if(student == null)
            {
                return NotFound($"The student with id {id} not found.");
            }
            CollegeRepository.Students.Remove(student);
            return Ok($"Student with ID {id} successfully deleted!");
        }
    }
}
