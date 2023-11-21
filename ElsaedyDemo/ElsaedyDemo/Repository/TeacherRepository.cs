using ElsaedyDemo.Models;
using ElsaedyDemo.MyContext;

namespace ElsaedyDemo.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _ApplicationDbConnection;
        public TeacherRepository(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbConnection = ApplicationDbContext;
        }

        public void Create(Teacher teacher)
        {
            _ApplicationDbConnection.teachers.Add(teacher);
            _ApplicationDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacher = (from Teacherobj in _ApplicationDbConnection.teachers
                               where Teacherobj.TeacherId == id
                               select Teacherobj).FirstOrDefault();

            _ApplicationDbConnection.teachers.Remove(teacher);
            _ApplicationDbConnection.SaveChanges();
        }

        public List<Teacher> GetAllTeacher()
        {
            try
            {
                List<Teacher> teachers = (from Teacherobj in _ApplicationDbConnection.teachers
                                          select Teacherobj).ToList();
                return teachers;

            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
