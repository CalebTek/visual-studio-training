namespace MVC.Demo.Models
{
    public class Student
    {
        // Fields
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Level { get; set; }
        public string Department { get; set; } = string.Empty;
        public List<Course> Courses { get; set; }

       // Constructor
        public Student()
        {
            Courses = new List<Course>();
        }
    }
}
