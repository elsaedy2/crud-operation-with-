using ElsaedyDemo.Models;
using ElsaedyDemo.MyContext;

namespace ElsaedyDemo.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly ApplicationDbContext _ApplicationDbConnection;
        public CourseRepository(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbConnection = ApplicationDbContext;
        }

        public void Create(Course courses)
        {
            _ApplicationDbConnection.courses.Add(courses);
            _ApplicationDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Course courses = (from Courseobj in _ApplicationDbConnection.courses
                         where Courseobj.CourseId == id
                         select Courseobj).FirstOrDefault();

            _ApplicationDbConnection.courses.Remove(courses);
            _ApplicationDbConnection.SaveChanges();
        }
        public List<Course> GetAllCourse()
        {
            try
            {
                List<Course> courses = (from Courseobj in _ApplicationDbConnection.courses
                                    select Courseobj).ToList();
                return courses;

            }
            catch (Exception ex)
            {

                return null;
            }
        }


    }
}


