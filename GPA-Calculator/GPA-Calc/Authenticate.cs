using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GPA_Calc
{
    internal class Authenticate
    {
        // Field
        //Course[] _course { get; set; }
        List<Course> _course { get; set; }
        
        // Constructor
        public Authenticate(List<Course> course) 
        {
            this._course = course;
        }

        // Method
        // Check if Course code exist
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

        // Check if course pattern match
        public bool Match(string courseCode)
        {
            Regex coursePattern = new Regex(@"^[A-z]{3}\d{3}$");
            if (!coursePattern.IsMatch(courseCode))
            {
                return false; 
            }
            return true;
        }

        public bool MatchKey(string key)
        {
            Regex keyPatter = new Regex(@"^[nNyY]$");
            if (!keyPatter.IsMatch(key))
            {
                return false;
            }
            return true;
        }

        public bool Length(string courseCode)
        {
            if (courseCode.Length !=6)
            {
                return false;
            }
            return true;
        }

        public bool IsLength(string num)
        {
            long length;
            if(!long.TryParse(num, out length) || length < 0 || length > 9)
            {
                return false;
            }
            return true;
        }

    }
}
