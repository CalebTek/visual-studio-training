using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesGPA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ReceiveData.GetCourseMax();
            int maxCourse = ReceiveData.GetCourseMax();
            Console.WriteLine(maxCourse);

            Data[] data = new Data[maxCourse];
            //var newData = ReceiveData.GetCourseData();

            /*foreach (var i in newData)
            {
                Console.WriteLine(i);
            }*/

            for (int i = 0; i < maxCourse; i++)
            {
                var newEntry = ReceiveData.GetCourseData();
                data[i] = new Data(newEntry);
            }
            foreach (var entry in data)
            {
                Console.WriteLine(entry.courseCode);
            }

            Console.WriteLine("COURSE & CODE\tCOURSE UNIT\tGRADE\tGRADE-UNIT\tWEIGHT POINT\tREMARK");
            foreach (var entry in data)
            {
                Console.WriteLine("{0,-10}\t{1,-10}\t{2,-10}\t{3,-10}\t{4,-10}", entry.courseCode, entry.courseUnit, entry.grade, entry.gradeUnit, entry.weightPoint, entry.remark);
            }

            Console.ReadKey();
        }
    }
}
