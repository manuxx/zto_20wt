namespace Training.DomainClasses
{
    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _isSatisfiedCriteria1;
        private readonly Criteria<TItem> _isSatisfiedCriteria2;

        public Conjunction(Criteria<TItem> isSatisfiedCriteria1, Criteria<TItem> isSatisfiedCriteria2)
        {
            _isSatisfiedCriteria1 = isSatisfiedCriteria1;
            _isSatisfiedCriteria2 = isSatisfiedCriteria2;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _isSatisfiedCriteria1.IsSatisfiedBy(item) && _isSatisfiedCriteria2.IsSatisfiedBy(item);
        }
    }
}