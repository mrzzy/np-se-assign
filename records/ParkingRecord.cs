using System;

namespace NP.SE.Assignment
{
    /* Defines a Parking Record that logs parking done by users */
    public class ParkingRecord
    {
        public int Id { get; private set; }
        public Vehicle Vehicle {get; private set; }
        public Carpark Carpark {get; private set; }
        public DateTime EntryTime  { get; private set; }
        public DateTime? ExitTime { get; private set; }
        public double AmountCharged { get; private set; }

        public ParkingRecord(int id, Vehicle vehicle, Carpark carpark, DateTime entryTime)
        {
            Id = id;
            Vehicle = vehicle;
            Carpark = carpark;
            EntryTime = entryTime;
            ExitTime = null;
            AmountCharged = 0.0;
        }

        public void setExitTime(DateTime endTime)
        {
            if (ExitTime == null)
                ExitTime = endTime;
        }

        public void setAmtCharged(double amt)
        {
            AmountCharged = amt;
        }
    }
}
