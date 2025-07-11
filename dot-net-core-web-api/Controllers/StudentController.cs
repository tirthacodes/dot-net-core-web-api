using dot_net_core_web_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_core_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<IEnumerable<Student>> GetStudentName()
        {
            var students = CollegeRepository.Students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                StudentName = s.StudentName,
                Address = s.Address,
                Email = s.Email
            });
            //Ok - 200 means success
            return Ok(CollegeRepository.Students);
        }

        [HttpGet("{id:int}", Name ="GetStudentbyId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> GetStudentbyId(int id)
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

            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Address = student.Address,
                Email = student.Email
            };

            //ok - success 200
            return Ok(studentDTO);
        }

        private Student GetStudentbyIdInfo(int id)
        {
            return CollegeRepository.Students.FirstOrDefault(s => s.Id == id);
        }


        [HttpGet("{name:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> GetStudentbyName(string name)
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

            var studentDTO = new StudentDTO
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Address = student.Address,
                Email = student.Email
            };


            //200 = ok success
            return Ok(studentDTO);
        }


        [HttpPost]
        [HttpGet("Create")]
        //route: api/student/create

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO model)
        {

            if (model == null)
            {
                return BadRequest();
            }

            int newId = CollegeRepository.Students.LastOrDefault().Id + 1;
            Student student = new Student
            {
                Id = newId,
                StudentName = model.StudentName,
                Address = model.Address,
                Email = model.Email
            };

            CollegeRepository.Students.Add(student);

            model.Id = student.Id;
            //status201
            //https://localhost:7067/api/student/4
            //new student details
            return CreatedAtRoute("GetStudentbyId", new {id = model.Id }, model);
        }
       
        [HttpDelete("{id:int}", Name ="DeleteStudentbyID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

