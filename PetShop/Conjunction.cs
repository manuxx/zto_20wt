namespace Training.DomainClasses
{
    public class Conjunction : Criteria<Pet>
    {
        private readonly Criteria<Pet> _leftCriteria;
        private readonly Criteria<Pet> _rightCriteria;

        public Conjunction(Criteria<Pet> leftCriteria, Criteria<Pet> rightCriteria)
        {
            _leftCriteria = leftCriteria;
            _rightCriteria = rightCriteria;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return _leftCriteria.IsSatisfiedBy(pet) && _rightCriteria.IsSatisfiedBy(pet);
        }
    }
}