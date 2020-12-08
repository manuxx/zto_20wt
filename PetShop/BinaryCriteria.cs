namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TItem> : Criteria<TItem>
    {
        protected Criteria<TItem> _criteriaLeft;
        protected Criteria<TItem> _criteriaRight;

        protected BinaryCriteria(Criteria<TItem> criteriaLeft, Criteria<TItem> criteriaRight)
        {
            _criteriaLeft = criteriaLeft;
            _criteriaRight = criteriaRight;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }
}