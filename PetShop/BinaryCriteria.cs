namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TItem> : Criteria<TItem>
    {
        protected Criteria<TItem> _isSatisfiedCriteria1;
        protected Criteria<TItem> _isSatisfiedCriteria2;

        public BinaryCriteria(Criteria<TItem> isSatisfiedCriteria1, Criteria<TItem> isSatisfiedCriteria2)
        {
            _isSatisfiedCriteria1 = isSatisfiedCriteria1;
            _isSatisfiedCriteria2 = isSatisfiedCriteria2;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }
}