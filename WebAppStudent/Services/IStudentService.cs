using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppStudent.Models;

namespace WebAppStudent.Services
{
    public interface IStudentService
    {
        Task<Student> GetStudentAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task DeleteStudentAsync(int id);
        Task<Student> UpdateStudentAsync(Student student);
    }
}
