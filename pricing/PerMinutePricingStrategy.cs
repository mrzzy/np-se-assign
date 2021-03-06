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
                    // $2 per hour of cars
                    return (2.0 / 60.0) * duration.TotalMinutes;
                default:
                    throw new NotSupportedException("Unsupported VehicleType given: " + vehicleType.ToString());
            }
        }
    }
}
