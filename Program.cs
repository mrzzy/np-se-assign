using System;
using System.Collections.Generic;

namespace NP.SE.Assignment
{
    class Program
    {

        private static List<User> userList = new List<User>();
        private static User currentUser;
        private static bool exit = false;

        static void Main(string[] args)
        {
            userList.Add(new NpUser("U01", "Sarah Teo", "npPassword", "98765432", "Credit Card"));
            userList.Add(new HrStaff("U02", "John Doe", "hrPassword", "87654321", "Debit Card"));

            while (!exit)
            {
                // while guests
                if (currentUser is null)
                    guestMenu();

                // while np user
                else if (currentUser is NpUser)
                    npUserMenu();

                // while hr staff
                else if (currentUser is HrStaff)
                    hrUserMenu();
            }
        }

        /*==================================== MENUS ====================================*/

        // --- Get Guest option
        static int guestMenuGetOption()
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("Welcome to NP Parking! Please login to use our services.\n");
            Console.WriteLine("(1) Login");
            Console.WriteLine("(2) Register\n");
            Console.WriteLine("(0) Exit");
            Console.WriteLine("========================================================");
            Console.Write("Option: ");
            string strAns = Console.ReadLine();
            Console.WriteLine("");

            return convertOptionToInt(strAns);
        }

        // --- Full guest menu
        static void guestMenu()
        {
            int option = guestMenuGetOption();
            switch (option)
            {
                case 0:
                    exit = true;
                    Console.WriteLine("Exiting!");
                    break;

                case 1:
                    Console.WriteLine("Logging in!");
                    login();

                    if (currentUser is null)
                    {
                        Console.WriteLine("Login unsuccessful!");
                        Console.WriteLine("");
                    }

                    break;

                case 2:
                    Console.WriteLine("Registering!");
                    break;

                default:
                    Console.WriteLine("Please enter an option between 1 to 2!");
                    break;
            }
        }

        // --- Get NP User option
        static int npUserMenuGetOption()
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("Welcome, " + currentUser.Name + "!\n");
            Console.WriteLine("(1) Register Vehicle");
            Console.WriteLine("(2) Apply Season Pass");
            Console.WriteLine("(3) Renew Season Pass");
            Console.WriteLine("(4) Transfer Season Pass");
            Console.WriteLine("(5) Terminate Season Pass\n");
            Console.WriteLine("(0) Exit");
            Console.WriteLine("========================================================");
            Console.Write("Option: ");
            string strAns = Console.ReadLine();
            Console.WriteLine("");

            return convertOptionToInt(strAns);
        }

        // --- Full NP User menu
        static void npUserMenu()
        {

            int option = npUserMenuGetOption();
            switch (option)
            {
                case 0:
                    exit = true;
                    Console.WriteLine("Exiting!");
                    break;

                case 1:
                    Console.WriteLine("Registering Vehicle!");
                    break;

                case 2:
                    Console.WriteLine("Applying for season pass!");
                    break;

                case 3:
                    Console.WriteLine("Renewing season pass!");
                    break;

                case 4:
                    Console.WriteLine("Transferring season pass!");
                    break;

                case 5:
                    Console.WriteLine("Terminating season pass!");
                    break;

                default:
                    Console.WriteLine("Please pick an option from 1 to 5!");
                    break;
            }
        }

        // --- Get HR User option
        static int hrUserMenuGetOption()
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("Welcome, " + currentUser.Name + "!\n");
            Console.WriteLine("(1) Process Season Application");
            Console.WriteLine("(2) Generate Financial Reports\n");
            Console.WriteLine("(0) Exit");
            Console.WriteLine("========================================================");
            Console.Write("Option: ");
            string strAns = Console.ReadLine();
            Console.WriteLine("");

            return convertOptionToInt(strAns);
        }

        // --- Full HR User menu
        static void hrUserMenu()
        {

                int option = hrUserMenuGetOption();
                switch (option)
                {
                    case 0:
                        exit = true;
                        Console.WriteLine("Exiting!");
                        break;

                    case 1:
                        Console.WriteLine("Processing season pass application!");
                        break;

                    case 2:
                        Console.WriteLine("Generating financial report!");
                        break;

                    default:
                        Console.WriteLine("Please pick an option from 1 to 2!");
                        break;
                }
        }

        /*==================================== OTHERS ====================================*/
        static void login()
        {
            Console.Write("User ID: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("");

            foreach (User user in userList)
            {
                if (user.UserId == username && user.Login(password))
                {
                    currentUser = user;
                    break;
                }
            }
        }

        static int convertOptionToInt(string opt)
        {
            try
            {
                return Convert.ToInt32(opt);
            }

            catch (FormatException)
            {
                return -1;
            }
        }
    }
}
