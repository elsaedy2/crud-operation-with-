using ElsaedyDemo.Models;

namespace ElsaedyDemo.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudent();

        public void Create(Student student);

        public void Delete(int id);

        public void Register(int StudentId, int CourseId);
    }
}
