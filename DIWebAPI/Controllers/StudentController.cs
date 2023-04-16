using DIWebAPI.Etities;
using DIWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public ActionResult<Student> AddStudent([FromBody] Student student)
        {
            try
            {
                var addedStudent = _studentService.AddStudent(student);
                return Ok(addedStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Student> UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                var updatedStudent = _studentService.UpdateStudent(id, student);
                if (updatedStudent == null)
                {
                    return NotFound();
                }
                return Ok(updatedStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            try
            {
                var student = _studentService.GetStudentById(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{id}")]
        public ActionResult<List<Student>> GetStudents()
        {
            try
            {
                var students = _studentService.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                _studentService.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
