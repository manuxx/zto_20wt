namespace Training.DomainClasses
{
    public abstract class BinaryCriteria<TItem> : Criteria<TItem>
    {
        protected Criteria<TItem> _firstcriteria;
        protected Criteria<TItem> _secondcriteria;

        public BinaryCriteria(Criteria<TItem> firstcriteria, Criteria<TItem> secondcriteria)
        {
            _firstcriteria = firstcriteria;
            _secondcriteria = secondcriteria;
        }

        public abstract bool IsSatisfiedBy(TItem item);
    }
}