using ElsaedyDemo.Models;
using ElsaedyDemo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ElsaedyDemo.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;
        public CourseController(ICourseRepository courseRepository , ITeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Course> course = _courseRepository.GetAllCourse();

            return View(course);
        }

        [HttpGet]
        public ViewResult Create()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeacher();
            return View(teachers);


        }
        [HttpPost]
        public ActionResult Create(Course courses)
        {
            if (courses != null)
            {
                _courseRepository.Create(courses);
            }
            List<Course> course = _courseRepository.GetAllCourse();


            return View( "Index", course);
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _courseRepository.Delete(id);

            }
            List<Course> course = _courseRepository.GetAllCourse();

            return View( "Index" , course);
        }
    }
}

