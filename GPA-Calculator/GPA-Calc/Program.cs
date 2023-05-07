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
                "\n \n \n";
            Console.WriteLine(appMSG);
            Console.Write("How many Course(s) do you want to register: ");
            string lengthInput = Console.ReadLine();
            long length;
            while (!long.TryParse(lengthInput, out length) || length < 1 || length > 100)
            {
                Console.Write($"Invalid input,Please enter integer numbers: ");
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
                    Regex coursePattern = new Regex(@"^[A-z]{3}\d{3}$");
                    while (!coursePattern.IsMatch(courseCodeInput) || !(courseCodeInput.Length == 6))
                    {
                        Console.Write($"Invalid input,Please enter Course {i + 1} Code in the following MTS509, GNS243, EEE453: ");
                        courseCodeInput = Console.ReadLine();
                    }
                    courseCode = courseCodeInput.ToUpper();               
                    Console.Write($"Enter Course {i + 1} Unit (0-9): ");
                    string courseUnitInput = Console.ReadLine();
                    long courseUnit;
                    while (!long.TryParse(courseUnitInput, out courseUnit) || courseUnit < 1 || courseUnit > 9)
                    {
                        Console.Write($"Invalid input,Please enter Course {i + 1} Unit between 0 and 9: ");
                        courseUnitInput = Console.ReadLine();
                    }
                    Console.Write($"Course {i + 1} Score (0-100): ");
                    string courseScoreInput = Console.ReadLine();
                    long courseScore;
                    while (!long.TryParse(courseScoreInput, out courseScore) || courseScore < 1 || courseScore > 100)
                    {
                        Console.Write($"Invalid input,Please enter Course {i + 1} Unit between 0 and 100: ");
                        courseScoreInput = Console.ReadLine();
                    }
                    courseArray[i] = new Course(courseCode, courseUnit, courseScore);
                    counter++;
                }
                if (counter == length) { input = false; }
            }

            TableDisplay resultDisplay = new TableDisplay(courseArray);
            resultDisplay.Table();
            Console.ReadKey();
        }
    }
}
