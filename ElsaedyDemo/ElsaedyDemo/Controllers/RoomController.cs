using ElsaedyDemo.Models;
using ElsaedyDemo.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ElsaedyDemo.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _RoomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _RoomRepository = roomRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Room> rooms = _RoomRepository.GetAllRoom();

            return View(rooms);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();


        }
        [HttpPost]
        public ActionResult Create(Room room)
        {
           
            
                _RoomRepository.Create(room);
          
            List<Room> rooms = _RoomRepository.GetAllRoom();
            return View("Index", rooms);
        }
        public ActionResult Delete(int id)
        {
            
                _RoomRepository.Delete(id);

          
            List<Room> rooms = _RoomRepository.GetAllRoom();
            return View("Index", rooms);


        }
    }
}
