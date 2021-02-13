using System;

namespace NP.SE.Assignment
{
    /* Represents a SeasonPass NpUser can purchase for long term parking in NP Carparks */
    public class SeasonPass
    {
        public int Id { get; private set; }
        public DateTime StartMonth { get; private set; }
        public DateTime EndMonth { get; private set; }
        public double PaidAmount { get; private set; }
        private SeasonPassState State { get; set; }

        public SeasonPass(int id, DateTime startMonth, DateTime endMonth)
        {
            Id = id;
            StartMonth = startMonth;
            EndMonth = endMonth;
            PaidAmount = 0.0;
            State = new UnprocessedSeasonPassState(this);
        }

        public SeasonPass(int id, DateTime startMonth, DateTime endMonth, double paidAmount, SeasonPassState state) : this(id, startMonth, endMonth)
        {
            PaidAmount = paidAmount;
            State = state;
        }

        public void Reject()
        {
            State = State.Reject();
        }

        public void Approve()
        {
            State = State.Approve();
        }

        public void Renew(int nMonth)
        {
            State = State.Renew(nMonth);
        }

        public void Park()
        {
            State = State.Park();
        }

        public void Exit()
        {
            State = State.Exit();
        }
    }
}
