namespace Training.DomainClasses
{
    public class Alternative<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _leftCriteria;
        private readonly Criteria<TItem> _rightCriteria;

        public Alternative(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
        {
            _leftCriteria = leftCriteria;
            _rightCriteria = rightCriteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _leftCriteria.IsSatisfiedBy(item) || _rightCriteria.IsSatisfiedBy(item);
        }
    }
}