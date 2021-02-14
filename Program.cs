using System;
using System.Collections.Generic;

namespace NP.SE.Assignment
{
    class Program
    {

        private static List<User> userList = new List<User>();
        private static User currentUser;
        private static List<Carpark> carparkList = new List<Carpark>();
        private static FinancialReport financialReport;
        private static Vehicle vehicle;
        private static SeasonPass sps;
        //private static List<FinancialReport.CarparkList> carParkList = new List<FinancialReport.CarparkList>();
        private static bool exit = false;

        static void Main(string[] args)
        {
            // dummy data

            userList.Add(new NpUser("U01", "Sarah Teo", "npPassword", "98765432", "Credit Card"));
            userList.Add(new NpUser("U02", "Jason Ang", "npPassword", "81729382", "Credit Card"));
            userList.Add(new HrStaff("U03", "John Doe", "hrPassword", "87654321", "Debit Card"));

            NpUser testUser = ((NpUser)userList[1]);
            testUser.registerVehicle(VehicleType.Car, "AMN6253L", "6273819203");
            testUser.registerVehicle(VehicleType.Car, "PLN7895L", "6273819204");
            testUser.registerVehicle(VehicleType.Car, "FCN0937J", "6273819205");
            testUser.registerVehicle(VehicleType.Car, "PTU9872C", "6273819206");

            FinancialReport financialReport = new FinancialReport();
            financialReport.carparks = new List<Carpark>();

            

            financialReport.carparks.Add(new Carpark(1, 30, "It is the smallest carpark and it is located near Makan Place", "Address 1"));
            financialReport.carparks.Add(new Carpark(2, 40, "It is the second biggest carpark and it is located near Munch.", "Address 2"));
            financialReport.carparks.Add(new Carpark(3, 50, "It is the biggest carpark and it is located near FoodClub.", "Address 2"));

            //carparkList.Add(new Carpark(1, 30, "It is the smallest carpark and it is located near Makan Place", "Address 1"));
            //carparkList.Add(new Carpark(2, 40, "This carpark as descriptive words that can be applied to it.", "Address 2"));
            //carparkList.Add(new Carpark(3, 50, "It is the biggest carpark and it is located near FoodClub.", "Address 3"));

            // Parking Records for Month of July for Car for All Carparks
            ParkingRecord parkingRecord1 = new ParkingRecord(001, testUser.vehicleList[0], financialReport.carparks[0], new DateTime(2020, 7, 9, 5, 15, 0));
            parkingRecord1.ExitTime = new DateTime(2020, 7, 9, 10, 15, 0);
            parkingRecord1.AmountCharged = testUser.vehicleList[0].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(300));
            financialReport.carparks[0].ParkingRecordList.Add(parkingRecord1);

            ParkingRecord parkingRecord2 = new ParkingRecord(002, testUser.vehicleList[1], financialReport.carparks[0], new DateTime(2020, 7, 10, 9, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2020, 7, 10, 16, 30, 0);
            parkingRecord1.AmountCharged = testUser.vehicleList[1].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(420));
            financialReport.carparks[0].ParkingRecordList.Add(parkingRecord2);

            ParkingRecord parkingRecord3 = new ParkingRecord(003, testUser.vehicleList[2], financialReport.carparks[0], new DateTime(2020, 7, 11, 7, 25, 0));
            parkingRecord1.ExitTime = new DateTime(2020, 7, 11, 21, 25, 0);
            parkingRecord1.AmountCharged = testUser.vehicleList[2].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(840));
            financialReport.carparks[0].ParkingRecordList.Add(parkingRecord3);

            ParkingRecord parkingRecord4 = new ParkingRecord(004, testUser.vehicleList[1], financialReport.carparks[1], new DateTime(2020, 7, 11, 7, 25, 0));
            parkingRecord1.ExitTime = new DateTime(2020, 7, 11, 20, 25, 0);
            parkingRecord1.AmountCharged = testUser.vehicleList[1].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(780));
            financialReport.carparks[0].ParkingRecordList.Add(parkingRecord4);

            ParkingRecord parkingRecord5 = new ParkingRecord(005, testUser.vehicleList[3], financialReport.carparks[1], new DateTime(2020, 7, 11, 10, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2020, 7, 11, 12, 30, 0);
            parkingRecord1.AmountCharged = testUser.vehicleList[3].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(120));
            financialReport.carparks[0].ParkingRecordList.Add(parkingRecord5);



            // Parking Records for Month of 

            // uncomment to test out parking and exit
            //carparkList[0].park(testUser.vehicleList[0]);
            //System.Threading.Thread.Sleep(120000); // sleep for 2 minute
            //carparkList[0].exit(testUser.vehicleList[0]);

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
                    bool success = registerVehicle();

                    if (success)
                        Console.WriteLine("Successfully registereed vehicle!");
                    else
                        Console.WriteLine("Please enter valid inputs!");

                    break;

                case 2:
                    Console.WriteLine("Applying for season pass!");
                    break;

                case 3:


                    //Console.WriteLine(currentUser.Name.ToString(),"/n", vehicle.LicenseNumber.ToString(),"/n", vehicle.IUNumber.ToString(),"/n", pass.EndMonth.ToString());
                    Console.WriteLine("Renewing season pass!");
               
                    break;

                case 4:
                    Console.WriteLine("Transferring season pass!");
                    break;

                case 5:
                    
                    Console.WriteLine("Terminating season pass!");
                    Terminate();
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

        /*==================================== MENU FUNCTIONS (?) ====================================*/
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

        static bool registerVehicle()
        {
            VehicleType vehicleType = getVehicleType();
            string licenseNumber = getLicenseNumber();
            string iUNumber = getIUNumber();

            return ((NpUser)currentUser).registerVehicle(vehicleType, licenseNumber, iUNumber);
        }

        /*==================================== OTHERS ====================================*/
        static VehicleType getVehicleType()
        {
            while (true)
            {
                // VehicleType type, string licenseNumber, int iUNumber, NpUser owner

                // Vehicle Type
                Console.WriteLine("1. Type of vehicle");
                Console.WriteLine("(1) Motorcycle");
                Console.WriteLine("(2) Car");
                Console.WriteLine("(3) Heavy Vehicles e.g. truck, bus");
                Console.Write("Option: ");
                string optStr = Console.ReadLine();
                Console.WriteLine("");
                int optInt = convertOptionToInt(optStr);

                switch (optInt)
                {
                    case 1:
                        return VehicleType.Motorcycle;

                    case 2:
                        return VehicleType.Car;

                    case 3:
                        return VehicleType.Heavy;

                    default:
                        Console.WriteLine("Please enter a number from 1 to 3!\n");
                        break;
                }
            }
        }
        /*==================================== Renew ====================================*/

        static SeasonPass Terminate()
        {
            return Terminate();
        }

        static string getLicenseNumber()
        {
            while (true)
            {
                Console.Write("License Number: ");
                string optStr = Console.ReadLine();

                return optStr;
            }
        }

        static string getIUNumber()
        {
            while (true)
            {
                Console.Write("IU Number: ");
                string optStr = Console.ReadLine();
                Console.WriteLine("");

                return optStr;
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

        private class CarparkList : FinancialReport.CarparkList
        {
        }
    }
}
