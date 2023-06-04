using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBank
{
    public  class Accountinfo
    {
        public string FullName { get; set; }
        public string Accountnumber { get; set; }
        public string Accounttype { get; set; }
        public decimal Accountbalance { get; set; }

        public Accountinfo(string fullname, string accountnumber, string accounttype, decimal accountbalance)
        {
            FullName = fullname;
            Accountnumber = accountnumber;
            Accounttype = accounttype;
            Accountbalance = accountbalance;
        }
    }
}
