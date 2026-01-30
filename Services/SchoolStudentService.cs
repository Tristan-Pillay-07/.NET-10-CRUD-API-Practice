using Microsoft.EntityFrameworkCore;
using NewCRUDAPI.Data;
using NewCRUDAPI.Dtos;
using NewCRUDAPI.Models;

namespace NewCRUDAPI.Services
{
    public class SchoolStudentService(ApplicationDbContext context) : ISchoolStudentService
    {

        public async Task<GetStudentDto> AddStudentAsync(CreateStudentRequest student)
        {
            var newStudent = new Student
            {
                Name = student.Name,
                Age = student.Age,
                Email = student.Email
            };

            context.Students.Add(newStudent);
            await context.SaveChangesAsync();

            return new GetStudentDto
            {
                Id = newStudent.Id,
                Name = newStudent.Name,
                Age = newStudent.Age,
                Email = newStudent.Email
            };
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var deleteStudent = context.Students.Find(id);
            if (deleteStudent == null)
            {
                return false;
            }
            context.Students.Remove(deleteStudent);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetStudentDto>> GetAllStudentsAsync()
            => await context.Students.Select(c => new GetStudentDto
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Email = c.Email
            }).ToListAsync();

        public async Task<GetStudentDto?> GetStudentByIdAsync(int id)
        {
            var result = await context.Students.Where(c=> c.Id == id).Select(c => new GetStudentDto
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Email = c.Email
            }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> UpdateStudentAsync(int id, UpdateStudentRequest student)
        {
            var existingStudent = await context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return false;
            }
            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.Email = student.Email;

            await context.SaveChangesAsync();
            return true;
        }

    }
}
