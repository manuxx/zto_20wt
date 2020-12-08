namespace Training.DomainClasses
{
    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(Criteria<TItem> criteriaLeft, Criteria<TItem> criteriaRight) : base(criteriaLeft, criteriaRight)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _criteriaLeft.IsSatisfiedBy(item) || _criteriaRight.IsSatisfiedBy(item);
        }
    }
}