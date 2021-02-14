using System.Collections.Generic;

namespace NP.SE.Assignment
{
    /** Represents a Vehicle at parks in NP Carparks */
    public class Vehicle {
        public VehicleType Type { get; private set; }
        public string LicenseNumber { get;  private set;}
        public string IUNumber { get; private set; }
        public NpUser Owner { get; private set; }
        public IIPricingStrategy PricingStrategy { get; private set; }
        public SeasonPass SPass { get; set; }

        public List<ParkingRecord> parkingRecordList { get; set; }

        public Vehicle(VehicleType type, string licenseNumber, string iUNumber, NpUser owner)
        {
            Type = type;
            LicenseNumber = licenseNumber;
            IUNumber = iUNumber;
            Owner = owner;
            PricingStrategy = new PerMinutePricingStrategy();
            parkingRecordList = new List<ParkingRecord>();
            SPass = null;
        }

        public Vehicle(VehicleType type, string licenseNumber, string iUNumber, NpUser owner, IIPricingStrategy pricingStrategy)
            : this(type, licenseNumber, iUNumber, owner) {
            PricingStrategy = pricingStrategy;
        }
    }
}
