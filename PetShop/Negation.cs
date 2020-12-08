namespace Training.DomainClasses
{

        public class Negation<TItem> : Criteria<TItem>
        {
            private readonly Criteria<TItem> _criteria4negation;

            public Negation(Criteria<TItem> criteria4negation)
            {
                _criteria4negation = criteria4negation;
            }

            public bool IsSatisfiedBy(TItem item)
            {
                return !_criteria4negation.IsSatisfiedBy(item);
            }
        }
}