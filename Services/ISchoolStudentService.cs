using NewCRUDAPI.Dtos;
using NewCRUDAPI.Models;

namespace NewCRUDAPI.Services
{
    public interface ISchoolStudentService
    {
        Task<List<GetStudentDto>> GetAllStudentsAsync();
        Task<GetStudentDto?> GetStudentByIdAsync(int id);
        Task<GetStudentDto> AddStudentAsync(CreateStudentRequest student);
        Task<bool> UpdateStudentAsync(int id, UpdateStudentRequest student);
        Task<bool> DeleteStudentAsync(int id);
    }
}
