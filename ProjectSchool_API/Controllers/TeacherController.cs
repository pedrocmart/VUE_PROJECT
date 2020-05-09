using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        public IRepository _repository { get; }
        public TeacherController(IRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllTeachersAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacherById(int teacherId)
        {
            try
            {
                var result = await _repository.GetTeacherAsyncById(teacherId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher model)
        {
            try
            {
                _repository.Add(model);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/teacher/{model.ID}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }

            return BadRequest();
        }

        [HttpPut("{teacherId}")]
        public async Task<IActionResult> Put(int teacherId, Teacher model)
        {
            Teacher student = await _repository.GetTeacherAsyncById(teacherId, false);

            if (student == null)
            {
                return NotFound();
            }

            _repository.Update(model);

            if (await _repository.SaveChangesAsync())
            {
                student = await _repository.GetTeacherAsyncById(teacherId, true);
                return Created($"/api/student/{model.ID}", student);
            }

            return BadRequest();
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> Delete(int teacherId)
        {
            try
            {
                Teacher teacher = await _repository.GetTeacherAsyncById(teacherId, false);

                if (teacher == null)
                {
                    return NotFound();
                }

                _repository.Delete(teacher);

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