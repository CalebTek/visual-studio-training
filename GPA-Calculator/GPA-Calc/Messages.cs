using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA_Calc
{
    internal class Messages
    {
        public string AppMSG()
        {
            string appMSG = "Welcome to the GPA Calculator Application. " +
            "\nTo calculate your GPA, input the following according to the prompt: " +
            "\n   1. Your Course Code e.g CSH101, NJS101, JVA101 etc. " +
            "\n   2. Course Unit (0-9). " +
            "\n   3. Course Score (0-100). " +
            "\n \n";
            return appMSG;
        }

        public string NumberOfCourse() => $"How many Course(s) do you want to register: ";

        public string NumberOfCourseERR() => $"Invalid input,Please enter a number: ";

        public string StartMSG() => "Would you like to begin registering the courses? Y or N: ";

        public string CourseCodeERR()
        {

            string courseCodeMSG = $"Invalid input" +
                $"\nNote:" +
                $"\nCSH101, NJS101, and JVA101 are examples of acceptable course codes." +
                $"\nCourse Code must be six (6) characters long." +
                $"\nThere must be three (3) alphabets and numbers in the course code." +
                $"\nCourse Code must not be blank." +
                $"\nThe same course code cannot be registered twice.\n";

            return courseCodeMSG;
        }


        public string CourseUnitERR()
        {
            string courseUnitErr = $"Invalid input" +
                $"\nNote:" +
                $"\nNo course unit can be lower than zero (0) or higher than nine (9).\n";
            return courseUnitErr;
        }

        public string CourseScoreERR()
        {
            string courseScoreErr = $"Invalid input" +
                $"\nNo course Score can be lower than zero (0) or higher than hundred (100).\n";
            return courseScoreErr;
        }

        // Some useful codes

        //Console.Write(courseLengthMSG);
        //string lengthInput = Console.ReadLine();
        //long length;
        //while (!long.TryParse(lengthInput, out length) || length < 1 || length > 100)
        //{
        //    Console.Write(courseLengthErr);
        //    lengthInput = Console.ReadLine();
        //}
        //Course[] courseArray = new Course[length];

        //for (int i = 0; i < length; i++)
        //{

        //Regex coursePattern = new Regex(@"^[A-z]{3}\d{3}$");
        //Authenticate check = new Authenticate(courseArray);
        //var matches = from courses in courseArray
        //              where courses.courseCode.ToLower() == courseCodeInput.ToLower()
        //              select courses;
        //!matches.Any() || 
        //while (!coursePattern.IsMatch(courseCodeInput) || !(courseCodeInput.Length == 6) || check.Exist(courseCodeInput))

        //while (!check.IsLength(courseUnitInput))

        //courseArray[i] = new Course(courseCode, courseUnit, courseScore);


        //ConsoleKeyInfo addInput = new ConsoleKeyInfo(' ', ConsoleKey.NoName, false, false, false);
        //ConsoleKeyInfo addInput = Console.ReadKey();
        //string isKey = addInput.KeyChar.ToString().ToLower();
        //char key;
        //string addKey = Console.ReadLine();

        //Regex isKey = new Regex(@"^[nNyY]$");
        //while (!(char.TryParse(isKey, out key))) // || (int)key != 121 || (int)key != 110

        //addKey = Console.ReadLine();

        //isKey = addInput.KeyChar.ToString().ToLower();
        //isKey = addInput.KeyChar;


        //default:
        //    input = false;
        //    break;


        //}
        //if (counter == length) { input = false; }

        //TableDisplay resultDisplay = new TableDisplay(courseArray);


      /*  Console.Write("\nPress enter to exit... ");

            default: Console.Write("\nExiting the Application... ");
            break;*/


    }
}
