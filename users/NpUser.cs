using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NP.SE.Assignment
{
    /* Represents a NP User that uses Parking System in order to park in NP Carparks */
    public class NpUser: User
    {
        public string PaymentMode { get; private set; }
        public List<Vehicle> vehicleList { get; private set; }

        public NpUser(string userId, string name, string password,
                string mobileNumber, string paymentMode)
        {
            this.UserId = userId;
            this.Name = name;
            this.PasswordHash = Hash(password);
            this.MobileNumber = mobileNumber;
            this.PaymentMode = paymentMode;
            this.vehicleList = new List<Vehicle>();
        }

        public void applySeasonPass()
        {
            while(true)
            {
                DateTime start = new DateTime();
                DateTime end = new DateTime();

                // get inputs
                Console.Write("License number: ");
                string licenseNumber = Console.ReadLine();

                Console.Write("Start Month (YYYY/MM): ");
                string startMonthStr = Console.ReadLine();

                Console.Write("End Month (YYYY/MM): ");
                string endMonthStr = Console.ReadLine();

                // validate inputs
                bool validLicense = Regex.IsMatch(licenseNumber, @"^[A-Za-z]{3}[\d]{4}[A-Za-z]{1}$");
                if (!validLicense)
                {
                    Console.WriteLine("Please enter a valid license number!\n");
                    continue;
                }

                bool validStartDate = Regex.IsMatch(startMonthStr, @"^([\d]{4})\/(0[1-9]|1[0-2])$");
                bool validEndDate = Regex.IsMatch(startMonthStr, @"^([\d]{4})\/(0[1-9]|1[0-2])$");

                if (validStartDate && validEndDate)
                {
                    // parse dates
                    int starty = Convert.ToInt32(startMonthStr.Substring(0, 4));
                    int startm = Convert.ToInt32(startMonthStr.Substring(5, 2));
                    start = new DateTime(starty, startm, 1, 0, 0, 0);

                    int endy = Convert.ToInt32(endMonthStr.Substring(0, 4));
                    int endm = Convert.ToInt32(endMonthStr.Substring(5, 2));
                    int lastDay = DateTime.DaysInMonth(endy, endm);
                    end = new DateTime(endy, endm, lastDay, 23, 59, 59);

                    // check for start date < now
                    DateTime today = DateTime.Now;
                    DateTime thisMonth = new DateTime(today.Year, today.Month, 1, 0, 0, 0);

                    if (thisMonth > start)
                    {
                        Console.WriteLine("The earliest starting date for season pass applications is this month.");
                        continue;
                    }
                    
                    // check for start date > end date
                    if (start > end)
                    {
                        Console.WriteLine("Cannot have an end date be before the start date!");
                        continue;
                    }
                }

                // find vehicle
                Vehicle vehicle = null;
                foreach (Vehicle aVehicle in vehicleList)
                {
                    if (aVehicle.LicenseNumber == licenseNumber)
                    {
                        vehicle = aVehicle;
                        break;
                    }
                }

                // vehicle exists?
                if (vehicle is null)
                {
                    Console.WriteLine("Please register your vehicle before applying for a season pass!\n");
                    continue;
                }

                else
                {
                    // vehicle have season pass?
                    if (vehicle.SPass != null)
                        Console.WriteLine("This vehicle already has a season pass!\n");

                    else
                    {
                        // calculate payment fees
                        int numOfMonths = ((end.Year - start.Year) * 12) + end.Month - start.Month + 1;
                        int paymentFees = numOfMonths * 30; // $30 per month
                        Console.WriteLine("Payment fees: $" + Convert.ToString(paymentFees));

                        // execute make payment use case
                        Console.WriteLine("Executing Make Payment fees\n");

                        // create season pass in unprocessed state
                        Random rnd = new Random();
                        int randId = rnd.Next();
                        SeasonPass newSeasonPass = new SeasonPass(randId, start, end);
                        vehicle.SPass = newSeasonPass;
                        break;
                    }
                }
            }
        }

        public bool registerVehicle(VehicleType type, string licenseNumber, string iUNumber)
        {
            // validate inputs
            bool validLicense = Regex.IsMatch(licenseNumber, @"^[A-Za-z]{3}[\d]{4}[A-Za-z]{1}$");
            bool validiU = Regex.IsMatch(iUNumber, @"^[\d]{10}$");

            if (validLicense && validiU)
            {
                // VehicleType type, string licenseNumber, int iUNumber, NpUser owner
                vehicleList.Add(new Vehicle(type, licenseNumber, iUNumber, this));
                return true;
            }

            return false;
        }
    }
}

