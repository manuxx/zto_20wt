namespace Training.DomainClasses
{
    public class Alternative<TITem> : Criteria<TITem>
    {
        private readonly Criteria<TITem> _firstCriteria;
        private readonly Criteria<TITem> _secondCriteria;

        public Alternative(Criteria<TITem> firstCriteria, Criteria<TITem> secondCriteria)
        {
            _firstCriteria = firstCriteria;
            _secondCriteria = secondCriteria;
        }

        public bool IsSatisfiedBy(TITem item)
        {
            return _firstCriteria.IsSatisfiedBy(item) || _secondCriteria.IsSatisfiedBy(item);
        }
    }
}