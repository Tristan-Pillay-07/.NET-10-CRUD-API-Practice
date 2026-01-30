using NewCRUDAPI.Models;

namespace NewCRUDAPI.Services
{
    public class SchoolStudentService : ISchoolStudentService
    {
        static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Mike", Age = 20, Email = "mike@gmail.com" },
            new Student { Id = 2, Name = "Leah", Age = 25, Email = "leah@gmail.com" },
            new Student { Id = 3, Name = "Tristan", Age = 24, Email = "leah@gmail.com" }

        };

        public Task<Student> AddStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetAllStudentsAsync()
            => await Task.FromResult(students);

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            var result = students.FirstOrDefault(s => s.Id == id);
            return await Task.FromResult(result);
        }

        public Task<bool> UpdateStudentAsync(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
