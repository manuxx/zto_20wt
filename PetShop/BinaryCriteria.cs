namespace Training.DomainClasses
{
    public class BinaryCriteria<TItem> : Criteria<TItem>
    {
        private Criteria<TItem> _leftCriteria;
        private Criteria<TItem> _rightCriteria;

        public BinaryCriteria(Criteria<TItem> leftCriteria, Criteria<TItem> rightCriteria)
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