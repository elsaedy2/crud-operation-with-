using ElsaedyDemo.Models;

namespace ElsaedyDemo.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourse();
        public void Create(Course courses);
        public void Delete(int id);
    }
}
