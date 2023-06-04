using Microsoft.Win32;
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace OneBank
{


    class Program
    {
        public static List<Accountinfo>AllInfo = new List<Accountinfo>();
      


        static void Main(string[] args)
        {
            Container();
        }

        public static void Container()
        {
            Console.WriteLine("Welcome to OneBank. What would you like to do today ?");
            Console.WriteLine(">Press 1 for Registration\n>Press 2 for login\n>Press 3 to exit.");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                var reg = new Registration();
                reg.RegisterMe();
            }
            else if (choice == "2")
            {
                var log = new Login();
                log.LogMe();
            }
            else
            {
                Console.WriteLine("Thanks for your time with us. Bye.");
                Environment.Exit(0);
            }
        }

    }
}