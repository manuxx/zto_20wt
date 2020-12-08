namespace Training.DomainClasses
{
    public class Conjuction<TItem> : BinaryCriteria<TItem>
    {
        public Conjuction(Criteria<TItem> firstCriteria, Criteria<TItem> secondCriteria) : base(firstCriteria, secondCriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _firstCriteria.IsSatisfiedBy(item) && _secondCriteria.IsSatisfiedBy(item);
        }
    }
}