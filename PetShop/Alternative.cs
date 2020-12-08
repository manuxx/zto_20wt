namespace Training.DomainClasses
{
    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(Criteria<TItem> isSatisfiedCriteria1, Criteria<TItem> isSatisfiedCriteria2) : base(isSatisfiedCriteria1, isSatisfiedCriteria2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _isSatisfiedCriteria1.IsSatisfiedBy(item) || _isSatisfiedCriteria2.IsSatisfiedBy(item);
        }
    }
}