namespace Training.DomainClasses
{

    public class Alternative<TItem> : BinaryCriteria<TItem>
    {
        public Alternative(Criteria<TItem> firstcriteria, Criteria<TItem> secondcriteria) : base(firstcriteria, secondcriteria)
        {
        }

        public override bool IsSatisfiedBy(TItem item)
        {
            return _firstcriteria.IsSatisfiedBy(item) || _secondcriteria.IsSatisfiedBy(item);
        }
    }
}