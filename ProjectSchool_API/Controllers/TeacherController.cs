using Microsoft.AspNetCore.Mvc;

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        public TeacherController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{teacherId}")]
        public IActionResult Get(int teacherId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{teacherId}")]
        public IActionResult Put(int teacherId)
        {
            return Ok();

        }

        [HttpDelete("{teacherId}")]
        public IActionResult Delete(int teacherId)
        {
            return Ok();
        }
    }
}