using System;
using System.Linq;
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
        //FinancialReport financialReport = new FinancialReport();


        static void Main(string[] args)
        {
            // dummy data
            financialReport = new FinancialReport();

            userList.Add(new NpUser("U01", "Sarah Teo", "npPassword", "98765432", "Credit Card"));
            userList.Add(new NpUser("U02", "Jason Ang", "npPassword", "81729382", "Credit Card"));
            userList.Add(new HrStaff("U03", "John Doe", "hrPassword", "87654321", "Debit Card"));

            NpUser testUser = ((NpUser)userList[1]);

            // used in Financial Report dummy data
            testUser.registerVehicle(VehicleType.Car, "AMN6253L", "6273819203");
            testUser.registerVehicle(VehicleType.Car, "PLN7895L", "6273819204");
            testUser.registerVehicle(VehicleType.Car, "FCN0937J", "6273819205");
            testUser.registerVehicle(VehicleType.Car, "PTU9872C", "6273819206");
            testUser.registerVehicle(VehicleType.Car, "UIY8923G", "6273819207");
            testUser.registerVehicle(VehicleType.Car, "GRU098762F", "6273819208");
            testUser.registerVehicle(VehicleType.Motorcycle, "MTR9098E", "6273819209");
            testUser.registerVehicle(VehicleType.Motorcycle, "MTR8876E", "6273819210");
            testUser.registerVehicle(VehicleType.Motorcycle, "MTR6537E", "6273819211");
            testUser.registerVehicle(VehicleType.Car, "ILP0987F", "6273819212"); // have season pass
            testUser.registerVehicle(VehicleType.Car, "FGH0972H", "6273819213"); // have season pass
            testUser.registerVehicle(VehicleType.Motorcycle, "MTR6726E", "6273819214"); // have season pass

            // create season passes
            Random rnd = new Random();
            DateTime startDate = new DateTime(2021, 1, 1, 0, 0, 0);
            var lastDay = DateTime.DaysInMonth(2020,1);
            DateTime endDate = new DateTime(2021, 1, lastDay, 23, 59, 59);
            testUser.VehicleList[8].SPass = new SeasonPass(rnd.Next(), startDate, endDate);

            startDate = new DateTime(2021, 2, 1, 0, 0, 0);
            lastDay = DateTime.DaysInMonth(2021, 4);
            endDate = new DateTime(2021, 4, lastDay, 23, 59, 59);
            testUser.VehicleList[9].SPass = new SeasonPass(rnd.Next(), startDate, endDate);

            startDate = new DateTime(2021, 2, 1, 0, 0, 0);
            lastDay = DateTime.DaysInMonth(2021, 2);
            endDate = new DateTime(2021, 2, lastDay, 23, 59, 59);
            testUser.VehicleList[10].SPass = new SeasonPass(rnd.Next(), startDate, endDate);

            //FinancialReport financialReport = new FinancialReport();
            financialReport.carparks = new List<Carpark>();

           
            financialReport.carparks.Add(new Carpark(1, 30, "It is the smallest carpark and it is located near Makan Place", "Address 1"));
            financialReport.carparks.Add(new Carpark(2, 40, "It is the second biggest carpark and it is located near Munch.", "Address 2"));
            financialReport.carparks.Add(new Carpark(3, 50, "It is the biggest carpark and it is located near FoodClub.", "Address 2"));

            //carparkList.Add(new Carpark(1, 30, "It is the smallest carpark and it is located near Makan Place", "Address 1"));
            //carparkList.Add(new Carpark(2, 40, "This carpark as descriptive words that can be applied to it.", "Address 2"));
            //carparkList.Add(new Carpark(3, 50, "It is the biggest carpark and it is located near FoodClub.", "Address 3"));

            // Parking Records for Month of January 2021 for Car for All Carparks
            ParkingRecord parkingRecord1 = new ParkingRecord(001, testUser.VehicleList[0], financialReport.carparks[0], new DateTime(2021, 1, 9, 5, 15, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 1, 9, 10, 15, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[0].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(300));
            financialReport.carparks[0].ParkingRecordList.Add(parkingRecord1);

            ParkingRecord parkingRecord2 = new ParkingRecord(002, testUser.VehicleList[1], financialReport.carparks[0], new DateTime(2021, 1, 10, 9, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 1, 10, 16, 30, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[1].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(420));
            financialReport.carparks[0].ParkingRecordList.Add(parkingRecord2);

            ParkingRecord parkingRecord3 = new ParkingRecord(003, testUser.VehicleList[2], financialReport.carparks[0], new DateTime(2021, 1, 11, 7, 25, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 1, 11, 21, 25, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[2].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(840));
            financialReport.carparks[0].ParkingRecordList.Add(parkingRecord3);

            ParkingRecord parkingRecord4 = new ParkingRecord(004, testUser.VehicleList[1], financialReport.carparks[1], new DateTime(2021, 1, 21, 7, 25, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 1, 21, 20, 25, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[1].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(780));
            financialReport.carparks[1].ParkingRecordList.Add(parkingRecord4);

            ParkingRecord parkingRecord5 = new ParkingRecord(005, testUser.VehicleList[3], financialReport.carparks[1], new DateTime(2021, 1, 13, 10, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 1, 13, 12, 30, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[3].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(120));
            financialReport.carparks[1].ParkingRecordList.Add(parkingRecord5);

            ParkingRecord parkingRecord6 = new ParkingRecord(006, testUser.VehicleList[4], financialReport.carparks[2], new DateTime(2021, 1, 22, 14, 10, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 1, 22, 16, 10, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[4].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(120));
            financialReport.carparks[2].ParkingRecordList.Add(parkingRecord6);

            ParkingRecord parkingRecord7 = new ParkingRecord(007, testUser.VehicleList[5], financialReport.carparks[2], new DateTime(2021, 1, 10, 9, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 1, 10, 16, 30, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[5].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(420));
            financialReport.carparks[2].ParkingRecordList.Add(parkingRecord7);

            ParkingRecord parkingRecord14 = new ParkingRecord(014, testUser.VehicleList[9], financialReport.carparks[2], new DateTime(2021, 1, 25, 12, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 1, 25, 16, 30, 0);
            parkingRecord1.AmountCharged = 30;
            financialReport.carparks[2].ParkingRecordList.Add(parkingRecord14);


            // Parking Records for Month of February 2021 in Carpark 3 for Car
            ParkingRecord parkingRecord8 = new ParkingRecord(008, testUser.VehicleList[1], financialReport.carparks[2], new DateTime(2021, 2, 10, 5, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 2, 10, 12, 30, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[1].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(420));
            financialReport.carparks[2].ParkingRecordList.Add(parkingRecord8);

            ParkingRecord parkingRecord9 = new ParkingRecord(009, testUser.VehicleList[2], financialReport.carparks[2], new DateTime(2021, 2, 10, 6, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 2, 10, 13, 30, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[2].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(420));
            financialReport.carparks[2].ParkingRecordList.Add(parkingRecord9);

            ParkingRecord parkingRecord10 = new ParkingRecord(010, testUser.VehicleList[3], financialReport.carparks[2], new DateTime(2021, 2, 11, 6, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 2, 6, 13, 30, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[2].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(420));
            financialReport.carparks[2].ParkingRecordList.Add(parkingRecord10);

            ParkingRecord parkingRecord15 = new ParkingRecord(015, testUser.VehicleList[10], financialReport.carparks[2], new DateTime(2021, 2, 11, 6, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 2, 11, 13, 30, 0);
            parkingRecord1.AmountCharged = 30;
            financialReport.carparks[2].ParkingRecordList.Add(parkingRecord15);

            // Parking Records for Month of February 2021 in Carpark 2 for Motorcycle
            ParkingRecord parkingRecord11 = new ParkingRecord(011, testUser.VehicleList[6], financialReport.carparks[1], new DateTime(2021, 2, 10, 5, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 2, 10, 12, 30, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[6].PricingStrategy.computePrice(VehicleType.Motorcycle, TimeSpan.FromMinutes(420));
            financialReport.carparks[1].ParkingRecordList.Add(parkingRecord11);

            ParkingRecord parkingRecord12 = new ParkingRecord(012, testUser.VehicleList[7], financialReport.carparks[1], new DateTime(2021, 2, 10, 6, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 2, 10, 13, 30, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[7].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(420));
            financialReport.carparks[1].ParkingRecordList.Add(parkingRecord12);

            ParkingRecord parkingRecord13 = new ParkingRecord(013, testUser.VehicleList[8], financialReport.carparks[1], new DateTime(2021, 2, 13, 6, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 2, 13, 13, 30, 0);
            parkingRecord1.AmountCharged = testUser.VehicleList[7].PricingStrategy.computePrice(VehicleType.Car, TimeSpan.FromMinutes(420));
            financialReport.carparks[1].ParkingRecordList.Add(parkingRecord13);

            ParkingRecord parkingRecord16 = new ParkingRecord(016, testUser.VehicleList[10], financialReport.carparks[1], new DateTime(2020, 2, 15, 6, 30, 0));
            parkingRecord1.ExitTime = new DateTime(2021, 2, 5, 13, 30, 0);
            parkingRecord1.AmountCharged = 30;
            financialReport.carparks[1].ParkingRecordList.Add(parkingRecord16);

            // uncomment to test out parking and exit
            //carparkList[0].park(testUser.VehicleList[0]);
            //System.Threading.Thread.Sleep(120000); // sleep for 2 minute
            //carparkList[0].exit(testUser.VehicleList[0]);

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
                    ((NpUser)currentUser).applySeasonPass();
                    break;

                case 3:


                    //Console.WriteLine(currentUser.Name.ToString(),"/n", vehicle.LicenseNumber.ToString(),"/n", vehicle.IUNumber.ToString(),"/n", pass.EndMonth.ToString());
                    Console.WriteLine("Renewing season pass!");
                    ((NpUser)currentUser).Renew();
                    break;

                case 4:
                    Console.WriteLine("Transferring season pass!");
                    break;

                case 5:
                    
                    Console.WriteLine("Terminating season pass!");
                    ((NpUser)currentUser).Termination();
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
                        // Query season pass applications: season pass in unprocessed state
                        List<NpUser> npUsers = userList
                            .FindAll((user) => user is NpUser)
                            .Cast<NpUser>().ToList();

                        List<SeasonPass> unprocessedSeasonPasses = npUsers
                            .SelectMany((user) => user.VehicleList)
                            .Where((vehicle) => vehicle.SPass != null)
                            .Select((vehicle) => vehicle.SPass)
                            .Where((seasonPass) => seasonPass.State is UnprocessedSeasonPassState)
                            .ToList();
                        HashSet<int> unprocessedIds = unprocessedSeasonPasses
                            .Select((seasonPass) => seasonPass.Id)
                            .ToHashSet();

                        // Query mapping from SeasonPass Id to NpUser and Vehicle
                        Dictionary<int, NpUser> passUserMap = npUsers
                            // generate combinations of (SeasonPass Id, NpUser) pairs
                            .SelectMany((user) => unprocessedIds
                                    .Select((id) => new {SeasonPassId=id, NpUser=user}))
                            // filter to only pairs of NpUser that actually does have have the season pass with id (via vehicle)
                            .Where((userPassId) => userPassId.NpUser.VehicleList
                                    .Any((vehicle) => vehicle.SPass != null && vehicle.SPass.Id  == userPassId.SeasonPassId))
                            // construct dictionary using pairs
                            .ToDictionary((userPassId) => userPassId.SeasonPassId, (userPassId) => userPassId.NpUser);

                        // Query mapping from SeasonPass Id to NpUser and Vehicle
                        Dictionary<int, Vehicle> passVehicleMap = npUsers
                            .SelectMany((user) => user.VehicleList)
                            // generate combinations of (SeasonPass Id, Vehicle) pairs
                            .SelectMany((vechicle) => unprocessedIds
                                    .Select((id) => new {SeasonPassId=id, Vehicle=vechicle}))
                            // filter to only pairs of Vehicle that actually does have the season pass with id
                            .Where((vechiclePassId) =>
                                    vechiclePassId.Vehicle.SPass != null &&
                                    vechiclePassId.Vehicle.SPass.Id == vechiclePassId.SeasonPassId)
                            // construct dictionary using pairs
                            .ToDictionary((vehiclePassId) => vehiclePassId.SeasonPassId, (vehiclePassId) => vehiclePassId.Vehicle);


                        // Prompt season pass applications as menu to admin to select
                        Func<int> promptApplications = () => {
                            // display season pass applications for selection
                            Console.WriteLine("==============[Season Pass Applications]================");
                            for (int i = 1; i <= unprocessedSeasonPasses.Count; i++)
                            {
                                int passId = unprocessedSeasonPasses[i-1].Id;
                                Console.WriteLine($"({i}) Application {passId} by {passUserMap[passId].Name}");
                            }
                            Console.WriteLine("(0) Exit");
                            Console.WriteLine("==============[Season Pass Applications]================");
                            // prompt to allow admin to select application
                            Console.Write("Option: ");
                            int selectedOption = convertOptionToInt(Console.ReadLine());
                            Console.WriteLine("");
                            return selectedOption;
                        };

                        while(true)
                        {
                            int selectedOption = promptApplications();
                            if(selectedOption == 0)
                            {
                                break; // exit
                            }
                            else if(selectedOption < 0 || selectedOption > unprocessedSeasonPasses.Count)
                            {
                                // bad option selected: warn user and prompt the user again
                                Console.WriteLine($"Please pick an option from 0 to {unprocessedSeasonPasses.Count}!");
                                continue;
                            }

                            // Display the SeasonPass to allow the Admin to review or rejected
                            SeasonPass seasonPass = unprocessedSeasonPasses[selectedOption - 1];
                            Console.WriteLine($"==============[Season Pass Application {seasonPass.Id}]================");

                            Console.WriteLine("[Applicant]");
                            NpUser applicant = passUserMap[seasonPass.Id];
                            Console.WriteLine($"User Id: {applicant.UserId}");
                            Console.WriteLine($"Name: {applicant.Name}");
                            Console.WriteLine($"Mobile Number: {applicant.MobileNumber}");
                            Console.WriteLine($"Payment Mode: {applicant.PaymentMode}");
                            Console.WriteLine($"No. Owned Vehicles: {applicant.VehicleList.Count}");

                            Console.WriteLine("");
                            Console.WriteLine("[Vehicle]");
                            Vehicle vehicle = passVehicleMap[seasonPass.Id];
                            Console.WriteLine($"Vehicle Type: {vehicle.Type}");
                            Console.WriteLine($"License Number: {vehicle.LicenseNumber}");
                            Console.WriteLine($"IU Number: {vehicle.IUNumber}");

                            Console.WriteLine("");
                            Console.WriteLine("[Season Pass]");
                            Console.WriteLine($"Season Pass Id: {seasonPass.Id}");
                            string startMonthStr = seasonPass.StartMonth.ToString("mm/yyyy");
                            Console.WriteLine($"Start Month: {startMonthStr}");
                            string endMonthStr = seasonPass.EndMonth.ToString("mm/yyyy");
                            Console.WriteLine($"End Month: {endMonthStr}");
                            string paidAmountStr = seasonPass.PaidAmount.ToString("c");
                            Console.WriteLine($"Paid Amount: {paidAmountStr}");

                            Console.WriteLine($"==============[Season Pass Application {seasonPass.Id}]================");

                            Func<int> promptReview = () => {
                                Console.WriteLine("(1) Approve");
                                Console.WriteLine("(2) Reject");
                                Console.WriteLine("(0) Exit");
                                // prompt to allow admin to select application
                                Console.Write("Option: ");
                                int selectedOption = convertOptionToInt(Console.ReadLine());
                                return selectedOption;
                            };

                            while(true)
                            {
                                int reviewOption = promptReview();
                                if(reviewOption == 0)
                                {
                                    break; // exit
                                }
                                else if(reviewOption < 0 || reviewOption > 2)
                                {
                                    // bad option selected: warn user and prompt the user again
                                    Console.WriteLine("Please pick an option from 0 to 2");
                                    continue;
                                }

                                if(reviewOption == 1)
                                {
                                    seasonPass.Approve();
                                }
                                else if(reviewOption == 2)
                                {
                                    seasonPass.Reject();
                                }
                                break; // exit

                            }
                            break; // exit
                        }

                        break;

                    case 2:
                        Console.WriteLine("Generating financial report!");
                        financialReport.GenerateReport();
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
