namespace Demo.MVC.Models
{
    public class Student
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set;} = string.Empty;
        public int Age { get; set;}
        public int Level { get; set; }
        public string  Department { get; set; } = string.Empty;
        public List<Course> Courses { get; set; }

        public Student() 
        {
            Courses = new List<Course>();
        }
    }
}
