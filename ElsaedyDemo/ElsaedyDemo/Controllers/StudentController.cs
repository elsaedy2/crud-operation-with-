using ElsaedyDemo.Models;
using ElsaedyDemo.Models.VIEW_MODEL;
using ElsaedyDemo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ElsaedyDemo.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }
        //return list of student
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> stdlst =_studentRepository.GetAllStudent();
            return View(stdlst);  
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Student student)
        {
            _studentRepository.Create(student);
            List<Student> stdlst = _studentRepository.GetAllStudent();


            return View("Index" , stdlst);
        }
        public ViewResult Delete(int id)
        {
            _studentRepository.Delete(id);
            List<Student> stdlst = _studentRepository.GetAllStudent();


            return View("Index", stdlst);
        }
        [HttpGet]
        public ActionResult Register() 
        {
            StudentCourseVM data = new StudentCourseVM();
            data.courses= _courseRepository.GetAllCourse();
            data.students= _studentRepository.GetAllStudent();


            return View(data);
        
        
        }
        [HttpPost]
        public ActionResult Register(int StudentId, int CourseId)
        {

            _studentRepository.Register(StudentId, CourseId);
            return RedirectToAction("Register");


        }
    }
}
