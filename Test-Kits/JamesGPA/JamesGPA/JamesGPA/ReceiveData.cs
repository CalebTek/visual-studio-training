using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesGPA
{
    internal class ReceiveData
    {
        //method receives data for each course
        public static ArrayList GetCourseData()
        {
            Console.Clear();
            var prompt = new string[3] { "Input Course Code: ", "Input Course Unit", "Input Course Score" };
            var allInput = new ArrayList();
            //var allInput = new string[3];

            for (int i = 0; i < prompt.Length; i++)
            {
                Console.WriteLine(prompt[i]);
                string input = Console.ReadLine();
                allInput.Add(input);
            }
            Console.Clear();

            return allInput;
        }

        public static int GetCourseMax()
        {
            bool isInputValid = false;
            int value = 0;
            while (!isInputValid)
            {
                Console.WriteLine("Enter number of courses: ");
                string maxCourse = Console.ReadLine();
                if (int.TryParse(maxCourse, out value))
                {
                    isInputValid = true;
                }
            }

            return value;
        }
    }
}
