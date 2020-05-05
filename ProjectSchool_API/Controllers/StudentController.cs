using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        public StudentController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{studentId}")]
        public IActionResult Get(int studentId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{studentId}")]
        public IActionResult Put(int studentId)
        {
            return Ok();

        }

        [HttpDelete("{studentId}")]
        public IActionResult Delete(int studentId)
        {
            return Ok();
        }

    }
}