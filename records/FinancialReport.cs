using System;
using System.Collections.Generic;

namespace NP.SE.Assignment
{
   
    public class FinancialReport
    {
        public List<Carpark> carparks;
        public int month;
        private VehicleType vehicleType;
        

        //public CarparkList carParkList { get; internal set; }

        public void GenerateReport()
        {
            Console.Write("Enter the month for the Financial Report:");
            int monthchoice = Convert.ToInt32(Console.ReadLine());


            Console.Write("Do you want to generate reports for all Carparks? [Y/N]");
            string carparkchoice = Console.ReadLine();
            int countCars = 0;
            int countMotors = 0;
            double totalRevenue = 0;
            string monthname = "";


            if (carparkchoice == "N")
            {
                Console.Write("Choose a carpark location.");
                //int locationchoice = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < carparks.Count; i++)
                {
                    Carpark currentCarpark = carparks[i];
                    Console.WriteLine("( " + i + 1 + ") " + currentCarpark.Id);
                }

                Console.Write("Option: ");
                int locationchoice = Convert.ToInt32(Console.ReadLine());

                Carpark chosenPark = carparks[locationchoice - 1];


                Console.Write("Choose a vehicle type.\n1. Car\n2. Motorcyle\nEnter choice:");
                int vtypechoice = Convert.ToInt32(Console.ReadLine());
                //VehicleType vehicleType; 

                if (vtypechoice == 1)
                {
                    //Console.Write("=============" + DateTime.Now + "============="); 
                    //Console.Write("Financial Report of {} in the month of {}", vtypechoice, monthchoice);
                    //Console.Write("");
                    //Console.Write("Carpark {}", carparkchoice);
                    vehicleType = VehicleType.Car;
                }


                else if (vtypechoice == 2)
                {
                    vehicleType = VehicleType.Motorcycle;
                }

                
                foreach (ParkingRecord record in chosenPark.ParkingRecordList) {
                    //int countCars = 0;
                    //int countMotors = 0; 
                    //month = record.EntryTime.Month;
                    if (record.EntryTime.Month != monthchoice) { continue; }
                    monthname = record.EntryTime.ToString("MMMM");
                    if (vehicleType == VehicleType.Car) { countCars += 1; }
                    else if (vehicleType == VehicleType.Motorcycle)
                    { countMotors += 1; }

                    totalRevenue += record.AmountCharged;
                }


            }

            else if (carparkchoice == "Y") // all carparks
            {
                Console.Write("Choose a vehicle type.\n1. Car\n2. Motorcyle\nEnter choice:");
                int vtypechoice = Convert.ToInt32(Console.ReadLine());

                if (vtypechoice == 1)
                {
                    //Console.Write("=============" + DateTime.Now + "============="); 
                    //Console.Write("Financial Report of {} in the month of {}", vtypechoice, monthchoice);
                    //Console.Write("");
                    //Console.Write("Carpark {}", carparkchoice);
                    vehicleType = VehicleType.Car;
                }


                else if (vtypechoice == 2)
                {
                    vehicleType = VehicleType.Motorcycle;
                }

                foreach (Carpark chosenPark in carparks)
                {
              
                    foreach (ParkingRecord record in chosenPark.ParkingRecordList)
                    {
                        //int countCars = 0;
                        //int countMotors = 0; 
                        //month = record.EntryTime.Month;
                        if (record.EntryTime.Month != monthchoice) { continue; }
                        monthname = record.EntryTime.ToString("MMMM");
                        if (vehicleType == VehicleType.Car) { countCars += 1; }
                        else if (vehicleType == VehicleType.Motorcycle)
                        { countMotors += 1; }

                        totalRevenue += record.AmountCharged;
                       
                    }
                }

                

                // return something to prevent error 
                Console.WriteLine("=============" + DateTime.Now + "=============");
                Console.WriteLine("Monthly Financial Report of {0} in the month of {1}.",vehicleType, monthname);
                //Console.WriteLine("Carpark {0}", chosenPark);
                Console.WriteLine("Number of Entries: {0}", countCars);
                Console.WriteLine("Total Revenue Generated: {0}", totalRevenue);

                //Console.Write("Number of Season Pass Holders: {}",)

                
            } }

        public class CarparkList
        {
            internal void Add(Carpark carpark)
            {
                throw new NotImplementedException();
            }
        }
    }
}
