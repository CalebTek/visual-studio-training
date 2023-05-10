﻿using System;
using System.Collections.Generic;
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
                $"\nMTS509, gns243, and Csc453 are examples of acceptable course codes." +
                $"\nCourse Code must be six (6) characters long." +
                $"\nThere must be three (3) alphabets and numbers in the course code." +
                $"\nCourse Code must not be blank." +
                $"\nThe same course code cannot be registered twice.\n";

            string courseUnitErr = $"Invalid input" +
                $"\nNote:" +
                $"\nNo course unit can be lower than zero (0) or higher than nine (9).\n";

            string courseScoreErr = $"Invalid input" +
                $"\nNo course Score can be lower than zero (0) or higher than hundred (100).\n";

            Console.WriteLine(appMSG);
            //Console.Write(courseLengthMSG);
            //string lengthInput = Console.ReadLine();
            //long length;
            //while (!long.TryParse(lengthInput, out length) || length < 1 || length > 100)
            //{
            //    Console.Write(courseLengthErr);
            //    lengthInput = Console.ReadLine();
            //}
            //Course[] courseArray = new Course[length];
            List<Course> courseList = new List<Course>();
            Authenticate check = new Authenticate(courseList);
            Console.Write("Do you want to start? Y or N: ");
            ConsoleKeyInfo startKeyInput = Console.ReadKey();
            string startKey = startKeyInput.KeyChar.ToString();
            while (!check.MatchKey(startKey))
            {
                Console.WriteLine("Invalid input, Press Y or N: ");
                startKeyInput = Console.ReadKey();
                startKey = startKeyInput.KeyChar.ToString();
            }
            Console.WriteLine();
            switch (startKey)
            {
                case "n":
                case "N":
                    Console.WriteLine("Exiting Application, press enter to exit");
                    Environment.Exit(0);
                    break;
            }
            bool input = true;
            int counter = 0;
            while (input)
            {
                //for (int i = 0; i < length; i++)
                //{
                    Console.Write($"Enter Course {counter + 1} Code e.g MTS509, GNS243, EEE453: ");
                    string courseCodeInput = Console.ReadLine();
                    string courseCode;
                    //Regex coursePattern = new Regex(@"^[A-z]{3}\d{3}$");
                    //Authenticate check = new Authenticate(courseArray);
                    //var matches = from courses in courseArray
                    //              where courses.courseCode.ToLower() == courseCodeInput.ToLower()
                    //              select courses;
                    //!matches.Any() || 
                    //while (!coursePattern.IsMatch(courseCodeInput) || !(courseCodeInput.Length == 6) || check.Exist(courseCodeInput))
                    while (!check.Match(courseCodeInput) || !check.Length(courseCodeInput) || check.Exist(courseCodeInput.ToUpper()))
                    {
                        Console.Write(courseCodeMSG + $"Enter Course {counter + 1} Code: ");
                        courseCodeInput = Console.ReadLine();
                    }
                    courseCode = courseCodeInput.ToUpper();
                    Console.Write($"Enter Course {counter + 1} Unit (0-9): ");
                    string courseUnitInput = Console.ReadLine();
                    long courseUnit;
                    while (!long.TryParse(courseUnitInput, out courseUnit) || courseUnit < 0 || courseUnit > 9)
                    //while (!check.IsLength(courseUnitInput))
                    {
                        Console.Write(courseUnitErr + $"Enter Course {counter + 1} Unit: ");
                        courseUnitInput = Console.ReadLine();
                    }
                    Console.Write($"Course {counter + 1} Score (0-100): ");
                    string courseScoreInput = Console.ReadLine();
                    long courseScore;
                    while (!long.TryParse(courseScoreInput, out courseScore) || courseScore < 0 || courseScore > 100)
                    {
                        Console.Write(courseScoreErr + $"Enter Course {counter + 1} Score: ");
                        courseScoreInput = Console.ReadLine();
                    }
                //courseArray[i] = new Course(courseCode, courseUnit, courseScore);
                courseList.Add(new Course(courseCode, courseUnit, courseScore));
                    counter++;
                    Console.Clear();
                Console.Write("Do you want to add more? Y or N: ");

                //ConsoleKeyInfo addInput = new ConsoleKeyInfo(' ', ConsoleKey.NoName, false, false, false);
                //ConsoleKeyInfo addInput = Console.ReadKey();
                //string isKey = addInput.KeyChar.ToString().ToLower();
                //char key;
                //string addKey = Console.ReadLine();
                ConsoleKeyInfo addKeyInput = Console.ReadKey();
                string addKey = addKeyInput.KeyChar.ToString();
                //Regex isKey = new Regex(@"^[nNyY]$");
                //while (!(char.TryParse(isKey, out key))) // || (int)key != 121 || (int)key != 110
                while (!check.MatchKey(addKey))
                {
                    Console.WriteLine("Invalid input, Press Y or N: ");
                    //addKey = Console.ReadLine();
                    addKeyInput = Console.ReadKey();
                    addKey = addKeyInput.KeyChar.ToString();
                    //isKey = addInput.KeyChar.ToString().ToLower();
                    //isKey = addInput.KeyChar;
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
                    //default:
                    //    input = false;
                    //    break;
                }
                Console.WriteLine();

                //}
                //if (counter == length) { input = false; }
            }

            //TableDisplay resultDisplay = new TableDisplay(courseArray);
            TableDisplay resultDisplay = new TableDisplay(courseList);
            Console.Write("Do you want to display result? Y or N: ");
            //Console.WriteLine();
            ConsoleKeyInfo keyInput = Console.ReadKey();
            string isDisplay = keyInput.KeyChar.ToString();
            Console.WriteLine();
            while (!check.MatchKey(isDisplay))
            {
                Console.WriteLine("Invalid input, Press Y or N: ");
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
                    Console.WriteLine("Exiting Application, press enter to exit");
                    break;

                default: Console.WriteLine("Exiting the Application");
                    break;
            }

            
            Console.ReadKey();
        }
    }
}
