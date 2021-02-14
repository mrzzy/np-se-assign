using System;

namespace NP.SE.Assignment
{
    /* Defines a Season Parking Pass State */
    public abstract class SeasonPassState
    {
        public SeasonPassState(SeasonPass pass)
        {
            Pass = pass;
        }


        protected SeasonPass Pass { get; set; }

        public virtual SeasonPassState Reject()
        {
            throw new NotImplementedException();
        }

        public virtual SeasonPassState Approve()
        {
            
            throw new NotImplementedException();
        }

        public virtual SeasonPassState Renew(int nMonth)
            
        {
            int price = 0;
            bool status = true;
            while (status)
            {
                Console.WriteLine("Enter Number of months");
                string rpMonth = Console.ReadLine();
                bool r = Int32.TryParse(rpMonth, out nMonth);
                if (!r)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter valid number");
                    break;
                }
                if (nMonth<0 || nMonth >12)
                {
                    Console.WriteLine("Please enter a valid month between 1 - 12");
                    break;
                }

                Console.WriteLine("Renewed");
                Console.WriteLine("Extend season parking pass for another" + nMonth + "month(s)");

                string confirmation = Approve().ToString();
                if (confirmation.ToLower()=="y")
                {
                    Console.WriteLine("You decided to renew" + nMonth + "month(s) of your season parking pass \n");
                    Console.WriteLine("Calculating season pass amount..");

                    price = 80;
                    int amt = price * nMonth;
                    Console.WriteLine("Amount needed to pay $" + amt);
                    Console.WriteLine("Pass successfully extended for" + nMonth + "month(s)");


                    //Add payment record 
                    
                }


            }

            return Renew(nMonth);
        }

        public virtual SeasonPassState Park()
        {
            throw new NotImplementedException();
        }

        public virtual SeasonPassState Exit()
        {
            throw new NotImplementedException();
        }
    }
}
