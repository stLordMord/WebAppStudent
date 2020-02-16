using System.Threading.Tasks;
using System.Web.Mvc;
using WebAppStudent.Models;
using WebAppStudent.Services;
using WebAppStudent.ViewModels;

namespace WebAppStudent.Controllers
{
    public class StudentController : Controller
    {
        public readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<ActionResult> Index() // return all student
        {
            var students = await _studentService.GetStudentsAsync(); 

            return View(students);
        }

        public ActionResult AddStudent() // implementation of ViewModel (1)
        {
            var studentViewModel = new StudentViewModel
            {
                Title = "Add New Student",
                AddButtonTitle = "Add",
                RedirectUrl = Url.Action("Index", "Student") // refresh page Index for updating added students
            };

            return View(studentViewModel);
        }

        public async Task<ActionResult> DetailsOfStudent(int id) // about student by id
        {
            var student = await _studentService.GetStudentAsync(id);

            return View(new StudentViewModel { Id = student.StudentId, Name = student.StudentName });
        }

        [HttpPost]
        public async Task<ActionResult> SaveStudent(StudentViewModel studentViewModel, string redirectUrl) //save change after update
        {
            if (!ModelState.IsValid)   //validation
            {
                return View(studentViewModel);
            }

            var student = await _studentService.GetStudentAsync(studentViewModel.Id);
            if (student != null)
            {
                student.StudentName = studentViewModel.Name;  // rename

                await _studentService.UpdateStudentAsync(student);
            }

            return RedirectToLocal(redirectUrl);
        }

        public async Task<ActionResult> EditStudent(int id) // implementation of ViewModel (2)
        {
            var student = await _studentService.GetStudentAsync(id);

            var studentViewModel = new StudentViewModel
            {
                Title = "Edit Student",
                AddButtonTitle = "Save",
                RedirectUrl = Url.Action("Index", "Student"),
                Name = student.StudentName,
                Id = student.StudentId
            };

            return View(studentViewModel);
        }

        public async Task<ActionResult> DeleteStudent(int id) 
        {
            await _studentService.DeleteStudentAsync(id);

            return RedirectToAction("Index");  // updating the current page
        }

        [HttpPost]
        public async Task<ActionResult> AddNewStudent(StudentViewModel studentViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(studentViewModel);
            }

            var student = new Student
            {
                StudentName = studentViewModel.Name
            };

            await _studentService.AddStudentAsync(student);

            return RedirectToLocal(redirectUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Student");
        }
    }
}