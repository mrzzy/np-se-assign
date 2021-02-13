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

        public virtual SeasonPassState reject()
        {
            throw new NotImplementedException();
        }

        public virtual SeasonPassState approve()
        {
            throw new NotImplementedException();
        }

        public virtual SeasonPassState renew()
        {
            throw new NotImplementedException();
        }

        public virtual SeasonPassState terminate()
        {
            throw new NotImplementedException();
        }

        public virtual SeasonPassState refund()
        {
            throw new NotImplementedException();
        }

        public virtual SeasonPassState park()
        {
            throw new NotImplementedException();
        }

        public virtual SeasonPassState exit()
        {
            throw new NotImplementedException();
        }
    }
}
