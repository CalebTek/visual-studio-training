using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzLogic
{
    public class Student
    {
        public Student(string FirstName, string LastName, string Gender, int YOB)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Gender = Gender;
            this.YOB = YOB;

        }

        public int Age() => DateTime.Now.Year - YOB;

        //public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YOB { get; }
        public string Gender { get;}
    }
}
