using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebAppStudent.Models;

namespace WebAppStudent
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _studentRepository.GetStudents();
        }
    }
}