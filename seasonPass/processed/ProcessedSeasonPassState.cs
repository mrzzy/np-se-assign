namespace NP.SE.Assignment
{
    /* Defines the behaviour of a SeasonPass in a processed state */
    public abstract class ProcessedSeasonPassState : SeasonPassState
    {
        public ProcessedSeasonPassState(SeasonPass pass) : base(pass) {}
    }
}
