namespace Training.DomainClasses
{

    public class Alternative<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _firstcriteria;
        private readonly Criteria<TItem> _secondcriteria;

        public Alternative(Criteria<TItem> firstcriteria, Criteria<TItem> secondcriteria)
        {
            _firstcriteria = firstcriteria;
            _secondcriteria = secondcriteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _firstcriteria.IsSatisfiedBy(item) || _secondcriteria.IsSatisfiedBy(item);
        }
    }
}