using Microsoft.AspNetCore.Mvc;
using MVC.Demo.Models;

namespace MVC.Demo.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StudentList()
        {
            var student = new List<Student>();

            student.Add(new Student
            {
                Id = "CSC133530",
                FirstName = "John",
                LastName = "Wesley",
                Age = 17,
                Level = 500,
                Department = "Computer Science",
                Courses = new List<Course>
                {
                    new Course { Code = "CSC500", Unit = 4, Score = 90},
                    new Course { Code = "CSC501", Unit = 3, Score = 85},
                }
            });

            student.Add(new Student
            {
                Id = "CSC133531",
                FirstName = "John",
                LastName = "Wes",
                Age = 17,
                Level = 500,
                Department = "Computer Science",
                Courses = new List<Course>
                {
                    new Course { Code = "CSC500", Unit = 4, Score = 90},
                    new Course { Code = "CSC501", Unit = 3, Score = 85},
                    new Course {Code = "CSC503", Unit = 2, Score = 45}
                }
            });

            return View(student);
        }
    }
}
