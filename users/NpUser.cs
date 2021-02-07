namespace NP.SE.Assignment
{
    /* Represents a NP User that uses Parking System in order to park in NP Carparks */
    public class NpUser: User
    {
        public string PaymentMode { get; private set; }

        public NpUser(string userId, string name, string password,
                string mobileNumber, string paymentMode)
        {
            this.UserId = userId;
            this.Name = name;
            this.PasswordHash = Hash(password);
            this.MobileNumber = mobileNumber;
            this.PaymentMode = paymentMode;
        }
    }
}

