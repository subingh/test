using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace S_S.API.Controllers
{
    //https://localhost:7160/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // Get: https://localhost:7160/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "subin", "sujan", "ram", "shyam" };
            return Ok(studentNames);
        }
    }
}
