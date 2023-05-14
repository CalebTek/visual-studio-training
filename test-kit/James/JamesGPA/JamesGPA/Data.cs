using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JamesGPA
{
    public enum Grading
    {
        F = 1,
        E = 2,
        D = 3,
        C = 4,
        B = 5,
        A= 6,
    }
    internal class Data
    {
        public string courseCode;
        public byte courseUnit;
        public byte courseScore;
        public int weightPoint;
        public byte gradeUnit;
        public char grade;
        public string remark;

        public Data(ArrayList entries)
        {

            this.courseCode = Convert.ToString(entries[0]);
            this.courseUnit = Convert.ToByte(entries[1]);
            this.courseScore = Convert.ToByte(entries[2]);
            this.gradeUnit = GetGrade(courseScore);
            this.weightPoint = GetWeightedPoint(this.courseUnit, this.gradeUnit);
            this.grade = (char)(Grading)gradeUnit;


        }

        public int GetWeightedPoint(byte courseUnit, byte gradeUnit)
        {
            return courseUnit * gradeUnit;
        }

        public byte GetGrade(byte courseScore)
        {
            switch (courseScore)
            {
                case byte score when (score > 0 && score < 40):
                    this.remark = "Fail";
                    return 0;
                case byte score when (score > 39 && score < 45):
                    this.remark = "Pass";
                    return 1;
                case byte score when (score > 44 && score < 50):
                    this.remark = "Fair";
                    return 2;
                case byte score when (score > 49 && score < 60):
                    this.remark = "Good";
                    return 3;
                case byte score when (score > 59 && score < 70):
                    this.remark = "Very Good";
                    return 4;
                case byte score when (score > 69 && score < 100):
                    this.remark = "Excellent";
                    return 5;
                default:
                    return 0;

            }
        }
    }
}

