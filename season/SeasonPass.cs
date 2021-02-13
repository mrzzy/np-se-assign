using System;

namespace NP.SE.Assignment
{
    /* Represents a SeasonPass NpUser can purchase for long term parking in NP Carparks */
    public class SeasonPass
    {
        public int id { get; private set; }
        public DateTime StartMonth { get; private set; }
        public DateTime EndMonth { get; private set; }
        public double paidAmount { get; private set; }
        private SeasonPassState State { get; set; }
    }
}
