using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Common
{
    public static class Messages
    {
        public static string startMessage = $"1. Register\n2. Login\n3. Exit";
        public static string userMessage = $"1. Setup Account\n2. Deposit\n" +
            $"3. Withdraw\n4. Transfer\n" +
            $"5. Check Balance\n6. Print Account Statement";

    }
}
