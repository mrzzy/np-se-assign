using System;

namespace NP.SE.Assignment
{
    /** Defines a strategy for computing parking charges */
    public interface IIPricingStrategy
    {
        // compute the price of parking of parking the vehicle with the
        // given type for the given duration using this pricing strategy
        public double computePrice(VehicleType vehicleType, TimeSpan duration);
    }
}
