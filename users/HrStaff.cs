using System;

namespace NP.SE.Assignment 
{
    /* Represents a HR Staff that administers the parking system */
    public class HrStaff: User
    {
        public HrStaff(string userId, string name, string password, string mobileNumber, string paymentMode) 
        {
            this.UserId = userId;
            this.Name = name;
            this.PasswordHash = Hash(password);
            this.MobileNumber = mobileNumber;
            
        }
            
        public void GenerateFinancialReport()
        {
            throw new NotImplementedException();
        }
    }
}
