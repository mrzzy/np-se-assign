using System;
using System.Collections.Generic;

namespace NP.SE.Assignment
{
    /* Represents a carpark in NP managed by the Parking System */
    public class Carpark
    {
        public int Id { get; private set; }
        public int TotalParkingLots { get; private set; }
        public string Description { get; private set; }
        public string Address { get; private set; }
        public List<ParkingRecord> ParkingRecordList { get; private set; }
        public Carpark(int id, int totalParkingLots, string description, string address)
        {
            Id = id;
            TotalParkingLots = totalParkingLots;
            Description = description;
            Address = address;
            ParkingRecordList = new List<ParkingRecord>();
        }


        public void park(Vehicle vehicle)
        {
            int id = 0;

            // create parking record
            if (ParkingRecordList.Count > 0)
            {
                id = ParkingRecordList[ParkingRecordList.Count - 1].Id + 1;
            }

            ParkingRecord parkingRecord = new ParkingRecord(id, vehicle, this, DateTime.Now);
            ParkingRecordList.Add(parkingRecord);

            // add parking record to vehicle
            vehicle.parkingRecordList.Add(parkingRecord);

            // call vehicle's season parking parked method
            if (vehicle.SPass != null)
                vehicle.SPass.Park();
        }

        public void exit(Vehicle vehicle)
        {
            // get parking record
            foreach (ParkingRecord record in ParkingRecordList)
            {
                if (record.Vehicle == vehicle && record.ExitTime is null)
                {
                    // set exit time of parking record
                    record.ExitTime = DateTime.Now;

                    // set duration of parking
                    TimeSpan time = ((DateTime)(record.ExitTime)).Subtract(record.EntryTime);

                    // call vehicle's season parking exit method
                    if (vehicle.SPass != null)
                        vehicle.SPass.Exit();


                    // set parking price
                    double amt = vehicle.PricingStrategy.computePrice(vehicle.Type, time);
                    record.AmountCharged = amt;
                }
            }
        }
    }
}
