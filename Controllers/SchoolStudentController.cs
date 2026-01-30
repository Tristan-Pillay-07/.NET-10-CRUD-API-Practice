using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewCRUDAPI.Models;
using NewCRUDAPI.Services;
using System.Xml.Linq;

namespace NewCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolStudentController(ISchoolStudentService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
            => Ok(await service.GetAllStudentsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudent(int id)
        {
            var student = await service.GetStudentByIdAsync(id);
            if (student is null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);
        }
    }
}
