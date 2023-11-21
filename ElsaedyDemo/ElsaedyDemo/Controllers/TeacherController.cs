using ElsaedyDemo.Models;
using ElsaedyDemo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ElsaedyDemo.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teachers =_teacherRepository.GetAllTeacher();

            return View(teachers);
        }

        [HttpGet]
        public ViewResult Create()
        { 

            return View();
        
        
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            _teacherRepository.Create(teacher);
       
            List<Teacher> teachers = _teacherRepository.GetAllTeacher();

            return View("Index" , teachers);
        }
        public ActionResult Delete(int id)
        {
            if(id > 0)
            {
                _teacherRepository.Delete(id);

            }
            List<Teacher> teachers = _teacherRepository.GetAllTeacher();

            return View("Index", teachers);
          
        }
    }
}
