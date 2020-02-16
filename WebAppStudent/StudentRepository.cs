using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppStudent.Models;

namespace WebAppStudent
{
    public class StudentRepository
    {
        public readonly List<Student> _students;

        public StudentRepository()
        {
            _students = new List<Student> { new Student { Id = 1, Email = "stupid@gmail.com", FirstName = "Liudka", LastName = "Kohovich" } };
        }

        public async Task<List<Student>> GetStudents()
        {
            return await Task.Run(() => _students);
        }

        public async Task<Student> GetStudent(int id)
        {
            return await Task.Run(() => _students.FirstOrDefault(f => f.Id == id));
        }
    }
}