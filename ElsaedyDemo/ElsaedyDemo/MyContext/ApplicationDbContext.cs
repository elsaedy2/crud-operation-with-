using ElsaedyDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ElsaedyDemo.MyContext
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        // EF Core uses this method at design time to access the DbContext
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder => webBuilder.UseStartup<Startup>());
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<ApplicationDbContext>();

        public void Configure(IApplicationBuilder ApplicationDbContext, IWebHostEnvironment env)
        {
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Course> courses { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<StudentCourses> studentCourses { get; set; }
        public DbSet<Teacher> teachers { get; set; }
    }
}
  
       

