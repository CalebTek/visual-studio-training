using Bank.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Collector
{
    public class ConsoleDisplay : IDisplay
    {
        public void DisplayAccountInfo()
        {
            throw new NotImplementedException();
        }

        public void DisplayBalance()
        {
            throw new NotImplementedException();
        }

        public void DisplayMenu()
        {
            //throw new NotImplementedException();
            Console.WriteLine(Messages.startMessage);
            Console.WriteLine(">");
        }

        public void DisplayTransactionHistory(List<string> history)
        {
            //throw new NotImplementedException();
            foreach (var transaction in history)
            {
                Console.WriteLine(transaction);
            }

        }

        public void DisplayUserMenu()
        {
            //throw new NotImplementedException();
            Console.WriteLine(Messages.userMessage);
        }
    }
}
