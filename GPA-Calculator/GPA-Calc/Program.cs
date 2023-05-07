using System;
using System.Linq;

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
            long length = Convert.ToInt64(Console.ReadLine());
            Course[] courseArray = new Course[length];
            bool input = true;
            int counter = 0;
            while (input)
            {
                for (int i = 0; i < length; i++)
                {
                    Console.Write($"Enter Course {i + 1} Code e.g MTS509, GNS243, EEE453: ");
                    string courseCode = Console.ReadLine();               
                    Console.Write($"Enter Course {i + 1} Unit (0-9): ");
                    double courseUnit = Convert.ToDouble(Console.ReadLine());
                    Console.Write($"Course {i + 1} Score (0-100): ");
                    double courseScore = Convert.ToDouble(Console.ReadLine());
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
