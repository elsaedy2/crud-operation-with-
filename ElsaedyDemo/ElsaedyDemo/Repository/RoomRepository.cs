using ElsaedyDemo.Models;
using ElsaedyDemo.MyContext;

namespace ElsaedyDemo.Repository
{
    public class RoomRepository:IRoomRepository
    {
        private readonly ApplicationDbContext _ApplicationDbConnection;
        public RoomRepository(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbConnection = ApplicationDbContext;
        }

        public void Create(Room room)
        {
            _ApplicationDbConnection.rooms.Add(room);
            _ApplicationDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = (from Roomobj in _ApplicationDbConnection.rooms
                         where Roomobj.RoomId == id
                         select Roomobj).FirstOrDefault();

            _ApplicationDbConnection.rooms.Remove(room);
            _ApplicationDbConnection.SaveChanges();
        }

        public List<Room> GetAllRoom()
        {
            try
            {
                List<Room> rooms = (from Roomobj in _ApplicationDbConnection.rooms
                                    select Roomobj).ToList();
                return rooms;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
