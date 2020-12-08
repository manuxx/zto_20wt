namespace Training.DomainClasses
{
    public class Alternative<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _firstCriteria;
        private readonly Criteria<TItem> _secondCriteria;

        public Alternative(Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria)
        {
            _firstCriteria = firstCriteria;
            _secondCriteria = secondCriteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _firstCriteria.IsSatisfiedBy(item) || _secondCriteria.IsSatisfiedBy(item);
        }
    }
}