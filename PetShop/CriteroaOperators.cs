namespace Training.DomainClasses
{
    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria4negation;

        public Negation(Criteria<TItem> criteria4Negation)
        {
            _criteria4negation = criteria4Negation;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_criteria4negation.IsSatisfiedBy(item);
        }
    }

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

    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _firstCriteria;
        private readonly Criteria<TItem> _secondCriteria;

        public Conjunction(Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria)
        {
            _firstCriteria = firstCriteria;
            _secondCriteria = secondCriteria;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _firstCriteria.IsSatisfiedBy(item) && _secondCriteria.IsSatisfiedBy(item);
        }
    }
}