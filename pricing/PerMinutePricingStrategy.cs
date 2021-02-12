using System;

namespace NP.SE.Assignment
{
    public class PerMinutePricingStrategy : IIPricingStrategy
    {
        public double computePrice(VehicleType vehicleType, TimeSpan duration)
        {
            switch (vehicleType)
            {
                case VehicleType.Motorcycle:
                    // $1 per hour for motorcycles
                    return (1.0 / 60.0) * duration.TotalMinutes;
                case VehicleType.Car:
                    // $2 per hour fo cars
                    return (2.0 / 60.0) * duration.TotalMinutes;
                case VehicleType.Heavy:
                    // $5 per hour for heavy vehiclef
                    return (5.0 / 60.0) * duration.TotalMinutes;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
