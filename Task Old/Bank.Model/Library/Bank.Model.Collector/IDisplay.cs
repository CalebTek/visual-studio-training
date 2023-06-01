using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Collector
{
    public interface IDisplay
    {
        void DisplayMenu();
        void DisplayBalance();
        void DisplayTransactionHistory(List<string> history);
        void DisplayAccountInfo();
        void DisplayUserMenu();

    }
}
