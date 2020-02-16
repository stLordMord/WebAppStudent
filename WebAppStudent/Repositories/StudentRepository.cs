using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebAppStudent.Models;
using WebAppStudent.Repositories;

namespace WebAppStudent
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository()
        { }

        public async Task<Student> GetStudentAsync(int id) // search of student by id
        {
            Student result = null;

            using (var studentContext = new StudentContext())
            {
                result = await studentContext.Students.FirstOrDefaultAsync(f => f.StudentId == id);
            }

            return result;
        }

        public async Task<Student> AddStudentAsync(Student student) // adding student
        {
            Student result = null;

            using (var studentContext = new StudentContext())
            {
                result = studentContext.Students.Add(student);
                await studentContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync() // return list of student
        {
            var result = new List<Student>();

            using (var studentContext = new StudentContext())
            {
                result = await studentContext.Students.ToListAsync();
            }

            return result;
        }

        public async Task DeleteStudnetAsync(int id) // delete student by id
        {
            using (var studentContext = new StudentContext())
            {
                var student = await studentContext.Students.FirstOrDefaultAsync(f => f.StudentId == id);

                studentContext.Entry(student).State = EntityState.Deleted;

                await studentContext.SaveChangesAsync();
            }
        }

        public async Task<Student> UpdateStudentAsync(Student student) // update list
        {
            using (var studentContext = new StudentContext())
            {
                studentContext.Entry(student).State = EntityState.Modified;

                await studentContext.SaveChangesAsync();
            }

            return student;
        }
    }
}