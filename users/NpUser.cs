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

