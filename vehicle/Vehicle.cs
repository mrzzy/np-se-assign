namespace NP.SE.Assignment
{
    /** Represents a Vehicle at parks in NP Carparks */
    public class Vehicle {
        public string Type { get; private set; }
        public string LicenseNumber { get;  private set;}
        public int IUNumber { get; private set; }
        public NpUser owner { get; private set; }
        public IIPricingStrategy pricingStrategy { get; private set; }

        public Vehicle(string type, string licenseNumber, int iUNumber, NpUser owner, IIPricingStrategy pricingStrategy)
        {
            Type = type;
            LicenseNumber = licenseNumber;
            IUNumber = iUNumber;
            this.owner = owner;
            this.pricingStrategy = pricingStrategy;
        }
    }
}
