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

    public class Alternative<TItem> : BinaryCriteria<TItem>
    {

        public Alternative(Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria) : base(firstCriteria, secondCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _firstCriteria.IsSatisfiedBy(item) || _secondCriteria.IsSatisfiedBy(item);
        }

    }

    public class Conjunction<TItem> : BinaryCriteria<TItem>
    {
        public Conjunction(Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria) : base(firstCriteria, secondCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _firstCriteria.IsSatisfiedBy(item) && _secondCriteria.IsSatisfiedBy(item);
        }
    }
}