using System;
namespace NP.SE.Assignment
{
    /* Defines the behaviour of a SeasonPass in  a processed state */
    public class UnprocessedSeasonPassState : SeasonPassState
    {
        public UnprocessedSeasonPassState(SeasonPass pass) : base(pass) {}

        public override SeasonPassState Approve()
        {
            // cannot approve season pass that will immediately expire
            if(DateTime.Now > Pass.EndMonth)
            {
                throw new InvalidOperationException("Cannot approve a SeasonPass that will immediately expire.");
            }
            // transition pass to waiting state if approved before start month
            if(DateTime.Now < Pass.StartMonth)
            {
                return new WaitingSeasonPassState(Pass);
            }
            return new ExitedSeasonPassState(Pass);
        }

        public override SeasonPassState Reject()
        {
            return new RejectedSeasonPassState(Pass);
        }
    }
}
