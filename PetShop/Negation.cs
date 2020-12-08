namespace Training.DomainClasses
{
    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _isSatisfiedCriteria;

        public Negation(Criteria<TItem> isSatisfiedCriteria)
        {
            _isSatisfiedCriteria = isSatisfiedCriteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_isSatisfiedCriteria.IsSatisfiedBy(item);
        }
    }
}