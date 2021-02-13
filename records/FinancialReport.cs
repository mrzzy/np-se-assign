using System;
using System.Collections.Generic;

namespace NP.SE.Assignment
{
   
    public class FinancialReport
    {
        public List<ParkingRecord> records;
        public int month; 
        public string GenerateReport()
        {
            Console.Write("Enter the month for the Financial Report:"); 
            int monthchoice = Convert.ToInt32(Console.ReadLine()); 
            
            Console.Write("Do you want to generate reports for all Carparks? [Y/N]"); 
            string carparkchoice = Console.ReadLine(); 
            
            if (carparkchoice == "N")
            {
                Console.Write("Choose a carpark location.\nCarpark 1\nCarpark 2\nCarpark 3\nEnter nuumber of Carpark:");
                int locationchoice = Convert.ToInt32(Console.ReadLine()); 
                
                Console.Write("Choose a vehicle type.\n1. Car\n2. Motorcyle\nEnter choice:");
                int vtypechoice = Convert.ToInt32(Console.ReadLine()); 
                
                if (vtypechoice == 1)
                {
                    /// enter the report details and codes here
                }
                
                else if (vtypechoice == 2)
                {
                    /// enter the report details and codes here
                }
                
            }
            
            else if(carparkchoice == "Y")
            {
                Console.Write("Choose a vehicle type.\n1. Car\n2. Motorcyle\nEnter choice:");
                int vtypechoice = Convert.ToInt32(Console.ReadLine()); 
                
                if (vtypechoice == 1)
                {
                    /// enter the report details and codes here
                }
                
                else if (vtypechoice == 2)
                {
                    /// enter the report details and codes here
                }
                
            }

            // return something to prevent error 
            return "";
        }
    }
}
