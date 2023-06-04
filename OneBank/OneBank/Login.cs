using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneBank
{
    public  class Login:Registration // Don't inherit Registration,
                                     // you have a function that will be inherited which might not be useful here
    {
         public void LogMe() // Pass in a register list/Repository to know who want to login
        {
            Console.WriteLine("-------ONEBANK LOGIN PORTAL----------");
            Console.Write("Enter your email :>>");
            string myemail = Console.ReadLine();

            Console.Write("Enter your password :>>");
            string mypass = Console.ReadLine();

            if(Email == myemail && Password == mypass) //This line will change based on the register list
            {
                Console.WriteLine("Congrats!, you are Logged in.");
                var dash = new Dashboard();
                dash.Menu();
            }
            else
            {
                Console.WriteLine("Incorrect Credentials");
                Program.Container();
                
            }


        }











    }
}
