namespace Training.DomainClasses
{
    public class Alternative<TITem> : BinaryCriteria<TITem>
    {
        public Alternative(Criteria<TITem> firstCriteria, Criteria<TITem> secondCriteria) : base(firstCriteria, secondCriteria)
        {
        }

        public override bool IsSatisfiedBy(TITem item)
        {
            return _firstCriteria.IsSatisfiedBy(item) || _secondCriteria.IsSatisfiedBy(item);
        }
    }
}