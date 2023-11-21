using ElsaedyDemo.Models;

namespace ElsaedyDemo.Repository
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeacher();
        public void Create(Teacher teacher);
        public void Delete(int id);
    }
}
