using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Collector
{
    public interface IUserInput
    {
        int GetChoice();
        double GetAmount();
        string GetFirstName();
        string GetLastName();
        string GetOtherName();
        string GetEmailAddress();
        string GetPhoneNumber();
        string GetPassword();
        string GetAccountNo();
        string GetTargetAccount();
        string GetSourceAccount();
        int GetAccountType();

        string GotoNext();


    }
}
