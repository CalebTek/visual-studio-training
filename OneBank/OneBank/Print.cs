using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBank
{
    public class Print
    {
     public  void Out()
        {
            string retrieve = "";
            foreach (Accountinfo acc in Program.AllInfo)
            {
                retrieve += $"|     {acc.FullName,-15}|   {acc.Accountnumber,-15}|     {acc.Accounttype,-15}|      {acc.Accountbalance,-16}|\n";
            }
            Console.WriteLine("|--------------------|------------------|--------------------|----------------------|");
            Console.WriteLine("|     FULLNAME       |  ACCOUNT NUMBER  |   ACCOUNT TYPE     |   ACCOUNT BALANCE    |");
            Console.WriteLine("|--------------------|------------------|--------------------|----------------------|");
            Console.WriteLine(retrieve);
            Console.WriteLine("------------------------------------------------------------------------------------");
        }
    }
}
