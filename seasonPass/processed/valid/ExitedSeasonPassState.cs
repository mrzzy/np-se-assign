namespace NP.SE.Assignment
{
    /* Defines the behaviour of a SeasonPass in  a processed state */
    public class ExitedSeasonPassState : SeasonPassState
    {
        public ExitedSeasonPassState(SeasonPass pass) : base(pass) {}

        public override SeasonPassState Park()
        {
            return new ParkedSeasonPassState(Pass);
        }
    }
}
