using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace GPA_Calc
{
    class Program
    {
        static void Main(string[] args)
        {
                   
            string appMSG = "Welcome to the GPA Calculator Application. " +
                "\nTo calculate your GPA, input the following according to the prompt: " +
                "\n   1. Your Course Code e.g MTS509, GNS243, EEE453 etc. " +
                "\n   2. Course Unit (0-9). " +
                "\n   3. Course Score (0-100). " +
                "\n \n";
            string courseLengthMSG = $"How many Course(s) do you want to register: ";

            string courseLengthErr = $"Invalid input,Please enter a number: ";

            string courseCodeMSG = $"Invalid input" +
                $"\nNote:" +
                $"\nCourse Code format MTS509, GNS243, EEE453" +
                $"\nCourse Code must be of length six(6)" +
                $"\nCourse Code must contain three (3) alphabets and digits each" +
                $"\nCourse Code can't be empty." +
                $"\nCourse Code not previously registered";

            string courseUnitErr = $"Invalid input" +
                $"\nNote:"+
                $"\nCourse Unit can't be less than 0" +
                $"\nCourse Unit can't be more than 9\n";

            string courseScoreErr = $"Invalid input" +
                $"\nCourse Score can't be lsess than 0" +
                $"\nCourse Score can't be more than 100\n";

            Console.WriteLine(appMSG);
            Console.Write(courseLengthMSG);
            string lengthInput = Console.ReadLine();
            long length;
            while (!long.TryParse(lengthInput, out length) || length < 1 || length > 100)
            {
                Console.Write(courseLengthErr);
                lengthInput = Console.ReadLine();
            }
            Course[] courseArray = new Course[length];
            bool input = true;
            int counter = 0;
            while (input)
            {
                for (int i = 0; i < length; i++)
                {
                    Console.Write($"Enter Course {i + 1} Code e.g MTS509, GNS243, EEE453: ");
                    string courseCodeInput = Console.ReadLine();
                    string courseCode;
                    //Regex coursePattern = new Regex(@"^[A-z]{3}\d{3}$");
                    Authenticate check = new Authenticate(courseArray);
                    //var matches = from courses in courseArray
                    //              where courses.courseCode.ToLower() == courseCodeInput.ToLower()
                    //              select courses;
                    //!matches.Any() || 
                    //while (!coursePattern.IsMatch(courseCodeInput) || !(courseCodeInput.Length == 6) || check.Exist(courseCodeInput))
                    while (!check.Match(courseCodeInput) || !check.Length(courseCodeInput) || check.Exist(courseCodeInput.ToUpper()))
                    {
                        Console.Write(courseCodeMSG + $"Enter Course {i + 1} Code: ");
                        courseCodeInput = Console.ReadLine();
                    }
                    courseCode = courseCodeInput.ToUpper();
                    Console.Write($"Enter Course {i + 1} Unit (0-9): ");
                    string courseUnitInput = Console.ReadLine();
                    long courseUnit;
                    while (!long.TryParse(courseUnitInput, out courseUnit) || courseUnit < 0 || courseUnit > 9)
                    //while (!check.IsLength(courseUnitInput))
                    {
                        Console.Write(courseUnitErr + $"Enter Course {i + 1} Unit: ");
                        courseUnitInput = Console.ReadLine();
                    }
                    Console.Write($"Course {i + 1} Score (0-100): ");
                    string courseScoreInput = Console.ReadLine();
                    long courseScore;
                    while (!long.TryParse(courseScoreInput, out courseScore) || courseScore < 0 || courseScore > 100)
                    {
                        Console.Write(courseScoreErr + $"Enter Course {i + 1} Unit: ");
                        courseScoreInput = Console.ReadLine();
                    }
                    courseArray[i] = new Course(courseCode, courseUnit, courseScore);
                    counter++;
                    Console.Clear();

                    //ConsoleKeyInfo addInput = Console.ReadKey();
                    //char isKey = addInput.KeyChar;

                    //while (isKey != 'y' || isKey != 'y' || isKey != 'n' || isKey != 'N')
                    //{
                    //    addInput = Console.ReadKey();
                    //    isKey = addInput.KeyChar;
                    //}
                        
                    //switch (isKey)
                    //{
                    //    case 'y':
                    //    case 'Y':
                    //        input = true;
                    //        break;

                    //    case 'n':
                    //    case 'N':
                    //        input = false;
                    //        break;
                    //}

                }
                if (counter == length) { input = false; }
            }

            TableDisplay resultDisplay = new TableDisplay(courseArray);
            Console.Write("Do you want to display result? Y or N: ");
            //Console.WriteLine();
            ConsoleKeyInfo keyInput = Console.ReadKey();
            char isDisplay = keyInput.KeyChar;
            switch(isDisplay)
            {
                case 'y':
                case 'Y':
                    resultDisplay.Table();
                    break;

                case 'n':
                case 'N':
                    Console.WriteLine("Exiting Application, press enter to exit");
                    break;

                default: Console.WriteLine("Invalid Input, exiting the Application");
                    break;
            }
            
            Console.ReadKey();
        }
    }
}
