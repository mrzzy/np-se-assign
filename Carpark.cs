using System;

namespace NP.SE.Assignment
{
    /* Represents a carpark in NP managed by the Parking System */
    public class Carpark
    {
        public int Id { get; private set; }
        public int TotalParkingLots { get; private set; }
        public string Description { get; private set; }
        public string Address { get; private set; }

        public Carpark(int id, int totalParkingLots, string description, string address)
        {
            Id = id;
            TotalParkingLots = totalParkingLots;
            Description = description;
            Address = address;
        }


        public void park(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
