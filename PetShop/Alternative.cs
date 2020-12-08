namespace Training.DomainClasses
{
    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria) : base(leftCriteria, rightCriteria)
        {
        }


    }
}