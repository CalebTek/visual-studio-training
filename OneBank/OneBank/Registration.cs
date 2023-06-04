using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OneBank
{
    public class Registration
    {
        //registration fields
        public static string Fullname = "";
        public static string Email = "";
        public static string Password = "";


        public void RegisterMe() // Pass in Registration Class 
        {

            Console.WriteLine("Start your registration Process here.");
            Console.WriteLine("Dear Customer please enter your fullname: ");
            string FName = Console.ReadLine();
            Fullname += FName;


            Console.WriteLine($" please enter your perferred password: ");
            string pwd = Console.ReadLine();
            Password += pwd;

            Console.WriteLine("Please enter your Email Address: ");
            string mail = Console.ReadLine();
            Email += mail;

            // Implement a Register Repository/List

            Console.WriteLine("Congratulations! your registration was successful\nYour details have been saved.");

            Console.WriteLine("Do you want to login ? Y or N");
            string response = Console.ReadLine();
            if (response == "y" || response == "Y")
            {
                var log = new Login();
                log.LogMe();
            }
            else
            {
                Program.Container();
            }
        }
    }
} 
