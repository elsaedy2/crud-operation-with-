using ElsaedyDemo.Models;
using ElsaedyDemo.MyContext;

namespace ElsaedyDemo.Repository
{
    public interface IRoomRepository
    {
        public List<Room> GetAllRoom();
        public void Create(Room room);
        public void Delete(int id);





    }
}
  
