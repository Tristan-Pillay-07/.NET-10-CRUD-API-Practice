using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewCRUDAPI.Dtos;
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
        public async Task<ActionResult<List<GetStudentDto>>> GetStudents()
            => Ok(await service.GetAllStudentsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<List<GetStudentDto>>> GetStudent(int id)
        {
            var student = await service.GetStudentByIdAsync(id);
            if (student is null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<GetStudentDto>> AddStudent(CreateStudentRequest student)
        {
            var createdStudent = await service.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, UpdateStudentRequest student)
        {
            var isUpdated = await service.UpdateStudentAsync(id, student);
            if (!isUpdated)
            {
                return NotFound("Student not found");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var isDeleted = await service.DeleteStudentAsync(id);
            if (!isDeleted)
            {
                return NotFound("Student not found");
            }
            return NoContent();
        }
    }
}
