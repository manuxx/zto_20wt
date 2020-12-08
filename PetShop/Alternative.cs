namespace Training.DomainClasses
{
    public class Alternative<TItem> : BinaryCriteria<TItem>
    {

        public Alternative(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria) : base(leftCriteria, rightCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _leftCriteria.IsSatisfiedBy(item) || _rightCriteria.IsSatisfiedBy(item);
        }
    }
}