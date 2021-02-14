using System;
using System.Collections.Generic;

namespace NP.SE.Assignment
{
   
    public class FinancialReport
    {
        public List<Carpark> carparks;
        public int month;

        //public CarparkList carParkList { get; internal set; }

        public string GenerateReport()
        {
            Console.Write("Enter the month for the Financial Report:"); 
            int monthchoice = Convert.ToInt32(Console.ReadLine()); 

            
            Console.Write("Do you want to generate reports for all Carparks? [Y/N]"); 
            string carparkchoice = Console.ReadLine(); 
            int countCars = 0;
            int countMotors = 0;
            int totalRevenue = 0; 
           
            if (carparkchoice == "N")
            {
                Console.Write("Choose a carpark location.\nCarpark 1\nCarpark 2\nCarpark 3\nEnter nuumber of Carpark:");
                int locationchoice = Convert.ToInt32(Console.ReadLine()); 
                
                Console.Write("Choose a vehicle type.\n1. Car\n2. Motorcyle\nEnter choice:");
                int vtypechoice = Convert.ToInt32(Console.ReadLine()); 
                VehicleType vehicleType; 

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

                foreach (ParkingRecord record in ParkingRecordList) {
                    //int countCars = 0;
                    //int countMotors = 0; 
                    record.EntryTime.Month; 
                    if record.EntryTime.Month != monthchoice {continue}
                    if (vehicleType = VehicleType.Car) {countCars += 1}
                    else (vehicleType = VehicleType.Motorcycle) {countMotors +=1}

                    totalRevenue += record.AmountCharged; 
            }
                

            }
            
            else if(carparkchoice == "Y")
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

                foreach (ParkingRecord record in ParkingRecordList) {
                    record.EntryTime.Month; 
                    if record.EntryTime.Month != monthchoice {continue}
                    if (vehicleType = VehicleType.Car) {countCars += 1}
                    else (vehicleType = VehicleType.Motorcycle) {countMotors +=1}

                
                }

            // return something to prevent error 
            Console.Write("=============" + DateTime.Now + "============="); 
            Console.Write("Financial Report of {} in the month of {}", vtypechoice, monthchoice);
            Console.Write("");
            Console.Write("Carpark {}", carparkchoice);
            Console.Write("Number of Entries: {}", countCars);
            Console.Write("Total Revenue Generated: {}", totalRevenue);



            //Console.Write("Number of Season Pass Holders: {}",)

            return "";
        }

        public class CarparkList
        {
            internal void Add(Carpark carpark)
            {
                throw new NotImplementedException();
            }
        }
    }
}
