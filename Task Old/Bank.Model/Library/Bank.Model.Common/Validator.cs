using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank.Model.Common
{
    internal class Validator
    {
        public class Validation
        {



            public static bool InitialPromptValidation(string userInput)
            {
                bool IsValid = false;
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    if (userInput == "1" || userInput == "2")
                    {
                        IsValid = true;
                    }
                }



                return IsValid;
            }



            public static bool NameValidation(string name)
            {
                bool isValid = false;
                Regex checkName = new Regex("^[A-Z][a-zA-Z]*$");
                if (checkName.IsMatch(name))
                {
                    isValid = true;
                }



                return isValid;
            }



            public static bool EmailValidation(string email)
            {
                bool isValid = false;
                Regex checkEmail = new Regex("^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$");
                if (checkEmail.IsMatch(email))
                {
                    isValid = true;
                }



                return isValid;
            }



            public static bool PasswordValidation(string password)
            {
                bool isValid = false;
                Regex passwordValidation = new Regex("^(?=.*[a-zA-Z])(?=.*\\d)(?=.*[!@#$%^&*])[a-zA-Z\\d!@#$%^&*]{6,}$");
                if (passwordValidation.IsMatch(password))
                {
                    isValid = true;
                }



                return isValid;
            }




            // ...............................................................................................................
            // .................................LOGIN DETAILS VALIDATION CHECK................................................
            //................................................................................................................




            public static bool LoginEmailValidation(string fromCreate, string fromLogin)
            {
                bool isValid = false;



                if (fromCreate == fromLogin)
                {
                    isValid = true;
                }



                return isValid;
            }




            public static bool LoginPasswordValidation(string passwordFromCreate, string passwordFromLogin)
            {
                bool isValid = false;
                if (passwordFromCreate == passwordFromLogin)
                {
                    isValid = true;
                }



                return isValid;
            }






        }
    }
}
