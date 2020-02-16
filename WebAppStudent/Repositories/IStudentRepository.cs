using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppStudent.Models;

namespace WebAppStudent.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task DeleteStudnetAsync(int id);
        Task<Student> UpdateStudentAsync(Student student);
    }
}
