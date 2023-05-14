using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace GPA_Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Messages msg = new Messages();
            
            Console.WriteLine(msg.AppMSG());

            List<Course> courseList = new List<Course>();
            Authenticate check = new Authenticate(courseList);
            Console.Write(msg.StartMSG());
            ConsoleKeyInfo startKeyInput = Console.ReadKey();
            string startKey = startKeyInput.KeyChar.ToString();
            while (!check.MatchKey(startKey))
            {
                Console.Write("\nInvalid input, Press Y or N: ");
                startKeyInput = Console.ReadKey();
                startKey = startKeyInput.KeyChar.ToString();
            }
            Console.WriteLine();
            switch (startKey)
            {
                case "n":
                case "N":
                    Console.Write("\nExiting Application, press enter to exit");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }
            bool input = true;
            int counter = 0;
            while (input)
            {
                
                    Console.Write($"Enter Course {counter + 1} Code e.g CSH101, NJS101, JVA101: ");
                    string courseCodeInput = Console.ReadLine();
                    string courseCode;
                    while (!check.Match(courseCodeInput) || !check.Length(courseCodeInput) || check.Exist(courseCodeInput.ToUpper()))
                    {
                        Console.Write(msg.CourseCodeERR()+ $"Enter Course {counter + 1} Code: ");
                        courseCodeInput = Console.ReadLine();
                    }
                    courseCode = courseCodeInput.ToUpper();
                    Console.Write($"Enter Course {counter + 1} Unit (0-9): ");
                    string courseUnitInput = Console.ReadLine();
                    long courseUnit;
                    while (!long.TryParse(courseUnitInput, out courseUnit) || courseUnit < 0 || courseUnit > 9)
                    {
                        Console.Write(msg.CourseUnitERR() + $"Enter Course {counter + 1} Unit: ");
                        courseUnitInput = Console.ReadLine();
                    }
                    Console.Write($"Course {counter + 1} Score (0-100): ");
                    string courseScoreInput = Console.ReadLine();
                    long courseScore;
                    while (!long.TryParse(courseScoreInput, out courseScore) || courseScore < 0 || courseScore > 100)
                    {
                        Console.Write(msg.CourseScoreERR() + $"Enter Course {counter + 1} Score: ");
                        courseScoreInput = Console.ReadLine();
                    }
                courseList.Add(new Course(courseCode, courseUnit, courseScore));
                    counter++;
                    Console.Clear();
                Console.Write("Do you want to add more? Y or N: ");
                ConsoleKeyInfo addKeyInput = Console.ReadKey();
                string addKey = addKeyInput.KeyChar.ToString();
                while (!check.MatchKey(addKey))
                {
                    Console.Write("\nInvalid input, Press Y or N: ");
                    addKeyInput = Console.ReadKey();
                    addKey = addKeyInput.KeyChar.ToString();
                }

                switch (addKey)
                {
                    case "y":
                    case "Y":
                        input = true;
                        break;

                    case "n":
                    case "N":
                        input = false;
                        break;
                }
                Console.WriteLine();

            }

            // Display result
            TableDisplay resultDisplay = new TableDisplay(courseList);
            Console.Write("Do you want to display result? Y or N: ");
            ConsoleKeyInfo keyInput = Console.ReadKey();
            string isDisplay = keyInput.KeyChar.ToString();
            Console.WriteLine();
            while (!check.MatchKey(isDisplay))
            {
                Console.Write("\nInvalid input, Press Y or N: ");
                keyInput = Console.ReadKey();
                isDisplay = keyInput.KeyChar.ToString();
            }
            switch (isDisplay)
            {
                case "y":
                case "Y":
                    resultDisplay.Table();
                    break;

                case "n":
                case "N":
                    //Console.Write("\nPress enter to exit... ");
                    break;

            }
            Console.Write("\nPress enter to exit... ");
            Console.ReadKey();
        }
    }
}
