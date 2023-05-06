using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA_Calculator
{
    public class TableDisplay
    {
        Dictionary<string, int[]> convertedGrades = new Dictionary<string, int[]>();
        public TableDisplay(Dictionary<string, int[]> convertedGrades)
        {
            this.convertedGrades = convertedGrades;
        }
        public void Table()
        {
            Dictionary<int, string> gradeScale = new Dictionary<int, string> { { 5, "A/Excellent" }, { 4, "B/Very Good" }, { 3, "C/Good" }, { 2, "D/Fair" }, { 1, "E/Pass" }, { 0, "F/Fail" } };

            Console.WriteLine("|---------------|-------------|-------|------------|------------|-----------|");
            Console.WriteLine("| COURSE & CODE | COURSE UNIT | GRADE | GRADE-UNIT | WEIGHT Pt. |  REMARK   |");
            Console.WriteLine("|---------------|-------------|-------|------------|------------|-----------|");
            foreach (var courseCode in convertedGrades.Keys)
            {
                if (courseCode != "ccu" && courseCode != "cgu" && courseCode != "cwpt")
                {
                    Console.WriteLine("|    " + courseCode + "     |      " + convertedGrades[courseCode][1] + "      |   " + gradeScale[convertedGrades[courseCode][0]].Substring(0, 1) + "   |       " + convertedGrades[courseCode][0] + "    |" + convertedGrades[courseCode][2].ToString().PadLeft(11, ' ') + " | " + gradeScale[convertedGrades[courseCode][0]].Substring(2).PadLeft(10, ' ') + "|");
                }
            }
            Console.WriteLine("|--------------------------------------------------|------------|-----------|");
            Console.WriteLine();
            Console.WriteLine("Total Course Unit Registered is " + convertedGrades["ccu"][0]);
            Console.WriteLine();
            Console.WriteLine("Total Course Unit Passed is " + convertedGrades["cgu"][0]);
            Console.WriteLine();
            Console.WriteLine("Total Weight Point is " + convertedGrades["cwpt"][0]);
            Console.WriteLine();
            Console.WriteLine("Your GPA is = " + Math.Round((decimal)convertedGrades["cwpt"][0] / convertedGrades["ccu"][0], 2) + " to 2 decimal places.");


        }
    }
    public class GradeConverter
    {
        Dictionary<string, int[]> userGrades = new Dictionary<string, int[]>();
        public GradeConverter(Dictionary<string, int[]> userGrades)
        {
            this.userGrades = userGrades;
        }

        public Dictionary<string, int[]> unitConverter()
        {
            Dictionary<string, int[]> convertedUnit = new Dictionary<string, int[]>();
            int sumOfGu = 0;
            int sumOfWpt = 0;
            int sumOfCu = 0;

            //0 = score
            //1 = cu

            foreach (var key in userGrades.Keys)
            {
                convertedUnit[key] = new int[3];
                convertedUnit[key][1] = userGrades[key][1];
                if (userGrades[key][0] >= 70)
                {
                    convertedUnit[key][0] = 5;
                    convertedUnit[key][2] = 5 * convertedUnit[key][1];
                }
                else if (userGrades[key][0] >= 60 && userGrades[key][0] < 70)
                {
                    convertedUnit[key][0] = 4;
                    convertedUnit[key][2] = 4 * convertedUnit[key][1];
                }
                else if (userGrades[key][0] >= 50 && userGrades[key][0] < 60)
                {
                    convertedUnit[key][0] = 3;
                    convertedUnit[key][2] = 3 * convertedUnit[key][1];
                }
                else if (userGrades[key][0] >= 45 && userGrades[key][0] < 50)
                {
                    convertedUnit[key][0] = 2;
                    convertedUnit[key][2] = 2 * convertedUnit[key][1];
                }
                else if (userGrades[key][0] >= 40 && userGrades[key][0] < 45)
                {
                    convertedUnit[key][0] = 1;
                    convertedUnit[key][2] = 1 * convertedUnit[key][1];
                }
                else
                {
                    convertedUnit[key][0] = 0;
                    convertedUnit[key][2] = 0;
                }

                sumOfCu += convertedUnit[key][1];
                sumOfGu += convertedUnit[key][0];
                sumOfWpt += convertedUnit[key][2];
            }
            convertedUnit["ccu"] = new int[] { sumOfCu };
            convertedUnit["cgu"] = new int[] { sumOfGu };
            convertedUnit["cwpt"] = new int[] { sumOfWpt };
            return convertedUnit;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int[]> studentA = new Dictionary<string, int[]>();
            bool input = true;
            string courseCode = "";
            int[] scoreAndUnit = new int[2];
            Console.WriteLine("Welcome to the GP Calculator App. \n To calculate your GP Input the following according to the prompt: \n 1. Your course code e.g MTH101, CHM102, PHY101 etc. \n 2. Score (0-99) \n 3. grade \n \n \n");
            while (input)
            {
                Console.WriteLine("Type the course code e.g MTH101, CHM102, PHY101");
                courseCode = Console.ReadLine();
                if (studentA.ContainsKey(courseCode))
                {
                    Console.WriteLine("You already filled this course code");
                    continue;
                }
                if (courseCode.Length != 6 || courseCode.Contains(" ") || courseCode == "")
                {
                    Console.WriteLine("Course code should not contain space or less than 6 character like CHM101");
                    continue;
                }

                bool arrInputNotFilled = true;

                while (arrInputNotFilled)
                {
                    Console.WriteLine("Please put your score in " + courseCode + "PS: 0-99");
                    bool correctScore = int.TryParse(Console.ReadLine(), out int score);
                    if (correctScore && score < 100 && score > 0)
                    {
                        scoreAndUnit[0] = score;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, use number between 0-99");
                    }

                    Console.WriteLine("Please put the Course unit for " + courseCode + "PS: 0-9");
                    bool correctUnit = int.TryParse(Console.ReadLine(), out int unit);
                    if (correctUnit && unit >= 0 && unit <= 9)
                    {
                        scoreAndUnit[1] = unit;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, use number between 0-9");
                    }

                    studentA[courseCode] = scoreAndUnit;
                    scoreAndUnit = new int[] { 0, 0 };
                    arrInputNotFilled = false;
                }
                arrInputNotFilled = true;

                Console.WriteLine("Do you want to add more Courses? \n Y - add more course \n N - Calculate GP");
                bool cont = true;

                while (cont)
                {
                    string addMore = Console.ReadLine();

                    if (addMore.ToUpper() == "Y")
                    {
                        cont = false;
                    }
                    else if (addMore.ToUpper() == "N")
                    {
                        input = false;
                        cont = false;
                    }
                    else
                    {
                        Console.WriteLine("Please type Y or N to add more course or Calculate GP");
                    }
                }



                //studentA.Add (courseCode, scoreAndUnit);
            }

            GradeConverter studentGrade = new GradeConverter(studentA);
            var convertedGrade = studentGrade.unitConverter();
            //foreach(var key in convertedGrade.Keys) Console.WriteLine(key + convertedGrade[key][0]);
            TableDisplay resultDisplay = new TableDisplay(convertedGrade);
            resultDisplay.Table();

            Console.ReadKey();

        }
    }
}
