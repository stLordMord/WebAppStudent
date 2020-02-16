using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebAppStudent.Controllers
{
    public class StudentController : Controller
    {
        public readonly StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        // GET: Student
        public async Task<ActionResult> Index()
        {
            var students = await _studentService.GetStudents();

            return View(students);
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        public ActionResult EditStudent()
        {
            return View();
        }

        public ActionResult DeleteStudent()
        {
            return RedirectToAction("index"); // возвращает на другой метод
        }
    }
}