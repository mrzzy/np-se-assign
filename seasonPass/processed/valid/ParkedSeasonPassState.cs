namespace NP.SE.Assignment
{
    /* Defines the behaviour of a SeasonPass in  a processed state */
    public class ParkedSeasonPassState : SeasonPassState
    {
        public ParkedSeasonPassState(SeasonPass pass) : base(pass) {}

        public override SeasonPassState Exit()
        {
            return new ExitedSeasonPassState(Pass);
        }
    }
}
