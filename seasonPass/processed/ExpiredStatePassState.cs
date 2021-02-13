namespace NP.SE.Assignment
{
    /* Defines the behaviour of a SeasonPass in a expired state */
    public class ExpiredStatePassState : SeasonPassState
    {
        public ExpiredStatePassState(SeasonPass pass) : base(pass) {}

        public override SeasonPassState Renew(int nMonths)
        {
            Pass.EndMonth.AddMonths(nMonths);
            return this;
        }
    }
}
