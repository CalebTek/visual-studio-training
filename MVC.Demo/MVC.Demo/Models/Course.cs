using System.ComponentModel.DataAnnotations;

namespace MVC.Demo.Models
{
    public class Course
    {
        [Key]
        public string Code { get; set; } = string.Empty;
        public int Unit { get; set; }
        public int Score { get; set; }
        public Course() { }
    }
}
