using ElsaedyDemo.Models;
using ElsaedyDemo.MyContext;

namespace ElsaedyDemo.Repository
{
    public class StudentRepsitory : IStudentRepository
    {
        private readonly ApplicationDbContext _ApplicationDbConnection;

        public StudentRepsitory(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbConnection = ApplicationDbContext;
        } 
        public List<Student> GetAllStudent()
        {
            try
            {
                List<Student> students = (from stdsobj in _ApplicationDbConnection.students
                                          select stdsobj).ToList();
                return students;

            }
            catch (Exception ex)
            {
              
                return null;
            }
          
        } 
        public void Create(Student student)
        {
            _ApplicationDbConnection.students.Add(student);
            _ApplicationDbConnection.SaveChanges();
           
        }

        public void Delete(int id)
        {
           Student student= (from stdsobj in _ApplicationDbConnection.students
                             where stdsobj.StudentId == id
                             select stdsobj).FirstOrDefault();

            _ApplicationDbConnection.students.Remove(student);
            _ApplicationDbConnection.SaveChanges();
        }

       

        public void Register(int StudentId, int CourseId)
        {
            _ApplicationDbConnection.studentCourses.Add(new StudentCourses
            {
                StudentId = StudentId,
                CourseId = CourseId
            });
            _ApplicationDbConnection.SaveChanges();
        }
    }
}
