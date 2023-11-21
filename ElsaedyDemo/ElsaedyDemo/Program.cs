using ElsaedyDemo.MyContext;
using ElsaedyDemo.Repository;
using Microsoft.EntityFrameworkCore;
using System;










var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersWithViews();
//كود بناء هيكل المودل وترحيلها لقاعد البيانات 
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("MyConnection")


    ));
builder.Services.AddTransient<IStudentRepository , StudentRepsitory>();
builder.Services.AddTransient<ITeacherRepository , TeacherRepository>();
builder.Services.AddTransient<IRoomRepository, RoomRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
