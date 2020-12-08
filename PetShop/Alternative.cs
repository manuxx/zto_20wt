using System;

namespace Training.DomainClasses
{
    public class Alternative : Criteria<Pet>
    {
        private readonly Criteria<Pet> _leftCriteria;
        private readonly Criteria<Pet> _rightCriteria;

        public Alternative(Criteria<Pet> leftCriteria, Criteria<Pet> rightCriteria)
        {
            _leftCriteria = leftCriteria;
            _rightCriteria = rightCriteria;
        }

        public bool IsSatisfiedBy(Pet pet)
        {
            return _leftCriteria.IsSatisfiedBy(pet) || _rightCriteria.IsSatisfiedBy(pet);
        }
    }

    
}