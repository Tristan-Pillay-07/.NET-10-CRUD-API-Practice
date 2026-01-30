using NewCRUDAPI.Models;

namespace NewCRUDAPI.Services
{
    public interface ISchoolStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
