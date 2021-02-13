using System;

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
                Console.Write("Choose a carpark location." + \n + "Carpark 1" + \n + "Carpark 2" + \n + "Carpark 3" + \n + "Enter nuumber of Carpark:");
                int locationchoice = Convert.ToInt32(Console.ReadLine()); 
                
                Console.Write("Choose a vehicle type." + \n + "1. Car" + \n + "2. Motorcyle" + \n + "Enter choice:");
                int vtypechoice = Convert.ToInt32(Console.ReadLine()); 
                
                if (vtypechoice == 1)
                {
                    /// enter the report details and codes here
                }
                
                else (vtypechoice == 2)
                {
                    /// enter the report details and codes here
                }
                
            }
            
            elseif(carparkchoice == "Y"); 
            {
                Console.Write("Choose a vehicle type." + \n + "1. Car" + \n + "2. Motorcyle" + \n + "Enter choice:");
                int vtypechoice = Convert.ToInt32(Console.ReadLine()); 
                
                if (vtypechoice == 1)
                {
                    /// enter the report details and codes here
                }
                
                else (vtypechoice == 2)
                {
                    /// enter the report details and codes here
                }
                
            }
                
                    
            
        }
    }
}
