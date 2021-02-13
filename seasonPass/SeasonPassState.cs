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
            throw new NotImplementedException();
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
