using System;

namespace NP.SE.Assignment
{
    /* Defines the behaviour of a SeasonPass in a waiting state */
    public class WaitingSeasonPassState : SeasonPassState
    {
        public WaitingSeasonPassState(SeasonPass pass) : base(pass) {}

        public override SeasonPassState Park()
        {
            if(DateTime.Now > Pass.StartMonth) {
                return new ParkedSeasonPassState(Pass);
            }
            return this;
        }
    }
}
