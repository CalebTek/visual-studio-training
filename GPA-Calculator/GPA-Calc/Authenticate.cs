using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA_Calc
{
    internal class Authenticate
    {
        // Field
        Course[] _course { get; set; }
        
        // Constructor
        public Authenticate(Course[] course) 
        {
            this._course = course;
        }

        // Method
        public bool Exist(string courseCode)
        {
            bool exist = false;
            foreach (Course course in _course) 
            {
                if (course != null && course.courseCode == courseCode)
                {
                    exist = true;
                    break;
                }
            }
            return exist;
        }
    }
}
