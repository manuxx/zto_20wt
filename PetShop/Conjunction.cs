namespace Training.DomainClasses
{
    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {
        public Conjunction(Criteria<TItem> isSatisfiedCriteria1, Criteria<TItem> isSatisfiedCriteria2) : base(isSatisfiedCriteria1, isSatisfiedCriteria2)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _isSatisfiedCriteria1.IsSatisfiedBy(item) && _isSatisfiedCriteria2.IsSatisfiedBy(item);
        }
    }
}