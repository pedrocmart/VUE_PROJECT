using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        public IRepository _repository { get; }
        public StudentController(IRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllStudentsAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            try
            {
                var result = await _repository.GetStudentAsyncById(studentId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        [HttpGet("ByTeacher/{teacherId}")]
        public async Task<IActionResult> GetStudentByTeacherId(int teacherId)
        {
            try
            {
                var result = await _repository.GetStudentAsyncByTeacherId(teacherId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Student model)
        {
            try
            {
                _repository.Add(model);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/student/{model.ID}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }

            return BadRequest();
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> Put(int studentId, Student model)
        {
            try
            {
                Student student = await _repository.GetStudentAsyncById(studentId, false);

                if (student == null)
                {
                    return NotFound();
                }

                _repository.Update(model);

                if (await _repository.SaveChangesAsync())
                {
                    student = await _repository.GetStudentAsyncById(studentId, true);
                    return Created($"/api/student/{model.ID}", student);
                }

                return BadRequest();
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> Delete(int studentId)
        {
            try
            {
                Student student = await _repository.GetStudentAsyncById(studentId, false);

                if (student == null)
                {
                    return NotFound();
                }

                _repository.Delete(student);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

    }
}